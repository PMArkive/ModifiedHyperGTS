Imports System.Net, System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Text, System.Text.RegularExpressions
Imports System.Console

Module Module1

    Dim dnsserv, s As Socket

    Dim fakeIP As String = ""
    Dim localIP As String = ""

    'Dim log As String = Application.StartupPath & "\" & Path.GetFileNameWithoutExtension(Application.ExecutablePath) & ".log"
    Dim log As String = Path.ChangeExtension(Application.ExecutablePath, "log")

    Dim mustLog As Boolean = False
    Dim autoConf As Boolean = False
    Dim localOnly As Boolean = False
    Dim noLocal As Boolean = False
    Dim useAutoIPSwitching As Boolean = True

    Dim defaultDNSServer As String = My.Settings.defaultDNSServer()

    Sub Main(ByVal args As String())

        ForegroundColor = ConsoleColor.White
        WriteLine("*** Fake DNS server v0.3 by M@T ***")
        WriteLine("    Based on LordLandon's sendpkm.py")
        ResetColor()
        WriteLine()

        For Each arg As String In args
            If arg = "?" OrElse IsArg(arg, "?") OrElse arg.ToLower() = "--help" OrElse arg.ToLower() = "-h" Then
                showHelp()
                Environment.Exit(0)
            End If
        Next arg

        Dim extIPAlreadyGiven As Boolean = False
        Dim localIPAlreadyGiven As Boolean = False

        For Each arg As String In args
            If IsArg(arg, "auto") Then
                autoConf = True

            ElseIf IsArg(arg, "localonly") Then
                If noLocal Then
                    ForegroundColor = ConsoleColor.Red
                    BackgroundColor = ConsoleColor.White
                    Write("Fatal error")
                    ResetColor()
                    ForegroundColor = ConsoleColor.Red
                    WriteLine(" : you can't specify 'localonly' with 'nolocal' !")
                    ResetColor()
                    Environment.Exit(1)
                End If
                localOnly = True
                useAutoIPSwitching = False

            ElseIf IsArg(arg, "nolocal") Then
                If localOnly Then
                    ForegroundColor = ConsoleColor.Red
                    BackgroundColor = ConsoleColor.White
                    Write("Fatal error")
                    ResetColor()
                    ForegroundColor = ConsoleColor.Red
                    WriteLine(" : you can't specify 'nolocal' with 'localonly' !")
                    ResetColor()
                    Environment.Exit(1)
                End If
                noLocal = True
                useAutoIPSwitching = False

            ElseIf IsArg(arg, "log") Then
                mustLog = True

            ElseIf IsIPv4(arg) Then
                If extIPAlreadyGiven Then
                    ForegroundColor = ConsoleColor.Red
                    WriteLine("Error : please set the external IP address only once.")
                    WriteLine("To specify a local IP, use '/local:<IP>'.")
                    WriteLine("Using the first public IP given ({0}).", fakeIP)
                    ResetColor()
                    WriteLine()
                Else
                    fakeIP = arg
                    extIPAlreadyGiven = True
                End If

            ElseIf arg.ToLower().StartsWith("/local:") Or arg.ToLower().StartsWith("-local:") Or arg.ToLower().StartsWith("--local:") Then
                If IsIPv4(arg.Substring(If(arg.StartsWith("--"), 8, 7))) Then
                    If localIPAlreadyGiven Then
                        ForegroundColor = ConsoleColor.Red
                        WriteLine("Error : please set the local IP address only once.")
                        WriteLine("Using the first local IP given ({0}).", localIP)
                        ResetColor()
                        WriteLine()
                    Else
                        localIP = arg.Substring(If(arg.StartsWith("--"), 8, 7))
                        localIPAlreadyGiven = True
                    End If
                Else
                    ForegroundColor = ConsoleColor.Red
                    WriteLine("The IP given with '{0}' is not a valid IPv4 address.", Left(arg, If(arg.StartsWith("--"), 8, 7)))
                    WriteLine("The program will try and find it automatically.")
                    ResetColor()
                    WriteLine()
                End If

            ElseIf arg.ToLower().StartsWith("/dns:") OrElse arg.ToLower().StartsWith("-dns:") OrElse arg.ToLower().StartsWith("--dns:") Then
                If IsIPv4(arg.Substring(If(arg.StartsWith("--"), 6, 5))) Then
                    defaultDNSServer = arg.Substring(If(arg.StartsWith("--"), 6, 5))
                Else
                    ForegroundColor = ConsoleColor.Red
                    WriteLine("The IP given with '{0}' is not a valid IPv4 address.", Left(arg, If(arg.StartsWith("--"), 6, 5)))
                    WriteLine("Using the default DNS server : " & defaultDNSServer)
                    ResetColor()
                    WriteLine()
                End If

            Else
                ForegroundColor = ConsoleColor.Red
                WriteLine("Unknown argument : '{0}'. Continuing...", arg)
                ResetColor()
                WriteLine()
            End If
        Next arg

        Dim mustWriteLine As Boolean = False

        If Not IsIPv4(defaultDNSServer) Then
            ForegroundColor = ConsoleColor.Red
            BackgroundColor = ConsoleColor.White
            Write("Fatal error")
            ResetColor()
            ForegroundColor = ConsoleColor.Red
            WriteLine(" : no IP was given for the real DNS server.")
            WriteLine("The program can't continue.")
            WriteLine("Try setting an IP address in the file 'DNS_Server.exe.config'")
            WriteLine("or use parameter '/dns:'. See 'DNS_Server /?' for more details.")
            ResetColor()
            Environment.Exit(1)
        End If

        ForegroundColor = ConsoleColor.White
        Write(" -> IP of the real DNS server : ")
        ForegroundColor = ConsoleColor.Cyan
        WriteLine(defaultDNSServer)
        ResetColor()
        WriteLine()

        If Not localOnly Then
            If fakeIP = "" Then
                Try
                    fakeIP = New StreamReader(HttpWebRequest.Create("http://whatismyip.com/automation/n09230945.asp").GetResponse().GetResponseStream()).ReadToEnd

                    If Not IsIPv4(fakeIP) Then
                        ForegroundColor = ConsoleColor.Magenta
                        WriteLine("Unable to get your public IP automatically, the website seems to have a problem.")
                        ResetColor()

                        fakeIP = ""
                        Exit Try
                    End If

                    If Not autoConf Then
                        Write("I detected that your public IP is ")
                        ForegroundColor = ConsoleColor.Green
                        WriteLine(fakeIP)
                        ResetColor()

                        If Not DidUserSayYes("Do you want to use that IP address ?") Then
                            fakeIP = ""
                        End If
                    End If
                Catch
                    ForegroundColor = ConsoleColor.Magenta
                    WriteLine("Unable to get your public IP automatically, check your Internet connection.")
                    ResetColor()

                    fakeIP = ""
                End Try
            End If

            If Not IsIPv4(fakeIP) Then mustWriteLine = True

            Do Until IsIPv4(fakeIP)
                If fakeIP <> "" Then
                    ForegroundColor = ConsoleColor.Red
                    WriteLine("This is not a valid IP address !")
                    ResetColor()
                End If

                WriteLine()
                Write("Please enter the public IP of the fake GTS server : ")
                ForegroundColor = ConsoleColor.Green
                fakeIP = ReadLine()
                ResetColor()
            Loop

            If mustWriteLine Or Not (autoConf Or extIPAlreadyGiven) Then
                WriteLine()
                mustWriteLine = False
            End If

            ForegroundColor = ConsoleColor.White
            Write(" -> Using external IP ")
            ForegroundColor = ConsoleColor.Green
            WriteLine(fakeIP)
            ResetColor()
            WriteLine()
        End If

        If Not (noLocal Or localIPAlreadyGiven) Then
            For Each ip As IPAddress In Dns.GetHostEntry(Dns.GetHostName()).AddressList()
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    localIP = ip.ToString()
                    Exit For
                End If
            Next ip
            'localIP = ""
            If autoConf OrElse localOnly OrElse DidUserSayYes("Do you want to use automatic public/private IP switching ?") Then
                useAutoIPSwitching = Not localOnly

                If Not autoConf Then
                    If Not localOnly Then WriteLine()

                    Write("I detected that your local IP is ")
                    ForegroundColor = ConsoleColor.Yellow
                    WriteLine(localIP)
                    ResetColor()

                    If Not DidUserSayYes("Do you want to use that IP address ?") Then
                        localIP = ""
                    End If
                End If

                If localIP = "" Then
                    'If (Not autoConf) AndAlso (localOnly OrElse DidUserSayYes("Could not determine your local IP. Do you want to enter it manually ?")) Then
                    Do Until IsIPv4(localIP)
                        If localIP <> "" Then
                            ForegroundColor = ConsoleColor.Red
                            WriteLine("This is not a valid IP address !")
                            ResetColor()
                        End If

                        WriteLine()
                        Write("Please enter the private IP of the fake GTS server : ")
                        ForegroundColor = ConsoleColor.Yellow
                        localIP = ReadLine()
                        ResetColor()
                    Loop

                    'WriteLine()
                    'Else
                    'If localOnly Then
                    'ForegroundColor = ConsoleColor.Red
                    'WriteLine("Fatal error : '/localonly' was specified, but can't get a valid local IP.")
                    'ResetColor()
                    'Environment.Exit(1)
                    'Else
                    'WriteLine("Unable to get a valid local IP, deactivating automatic IP switching...")
                    'WriteLine()
                    'End If

                    'useAutoIPSwitching = False
                    'End If
                End If
            Else
                useAutoIPSwitching = False
            End If

            If Not autoConf Then WriteLine()
        End If

        If (Not noLocal) And (localOnly Or useAutoIPSwitching) Then
            ForegroundColor = ConsoleColor.White
            Write(" -> Using internal IP ")
            ForegroundColor = ConsoleColor.Yellow
            WriteLine(localIP)
            ResetColor()
            WriteLine()
        End If

        TreatControlCAsInput = True

        Dim thr As Thread = New Thread(AddressOf dnsspoof)
        thr.Start()

        Dim key As ConsoleKeyInfo

        While True
            key = ReadKey(True)

            If key.Modifiers = ConsoleModifiers.Control AndAlso key.Key = ConsoleKey.C Then
                Exit While
            End If
        End While

        dnsserv.Close()
        If thr.IsAlive() Then thr.Abort()
    End Sub

    Private Sub dnsspoof()
        dnsserv = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        dnsserv.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1)

        dnsserv.Bind(New IPEndPoint(IPAddress.Any, 53))

        WriteLine(GetTime() & "DNS server started.")
        WriteLine()

        If mustLog AndAlso File.Exists(log) AndAlso File.ReadAllBytes(log).Length > 0 Then
            File.AppendAllText(log, "----------------------------------------" & vbCrLf & vbCrLf)
        End If

        If mustLog Then File.AppendAllText(log, GetTime() & "DNS server started on " & CType(dnsserv.LocalEndPoint, IPEndPoint).ToString & vbCrLf & vbCrLf)

        Dim fakeIP_bytes(3) As Byte
        If Not localOnly Then
            For i = 0 To 3
                fakeIP_bytes(i) = CInt(fakeIP.Split(".")(i))
            Next i
        End If

        Dim localIP_bytes(3) As Byte
        If useAutoIPSwitching Or localOnly Then
            For i = 0 To 3
                localIP_bytes(i) = CInt(localIP.Split(".")(i))
            Next i
        End If

        Dim spoofedIP As String = ""
        Dim spoofedIP_bytes As Byte()

        Dim spoofTextColor As ConsoleColor

        Dim r(511), rr(511) As Byte
        Dim lngSnd, lngRcv As Integer
        Dim str_r, str_rr, rawHost As String

        Dim rem_ep As EndPoint = New IPEndPoint(IPAddress.Any, 0)

        While True
            Try
                ReDim r(511)
                lngRcv = dnsserv.ReceiveFrom(r, SocketFlags.None, rem_ep)

                ReDim Preserve r(lngRcv)

                str_r = Encoding.ASCII.GetString(r, 0, lngRcv)

                WriteLine(GetTime() & "Data from : " & CType(rem_ep, IPEndPoint).Address.ToString())

                If mustLog Then File.AppendAllText(log, GetTime() & "Data from : " & CType(rem_ep, IPEndPoint).ToString() & vbCrLf & _
                                                        str_r & vbCrLf & vbCrLf, Encoding.ASCII)

                rawHost = str_r.Substring(12, str_r.IndexOf(Chr(0), 12) - 12)

                Dim requestedHost As String = ""
                Dim n As Integer = 0

                While n < rawHost.Length
                    requestedHost &= rawHost.Substring(n + 1, r(n + 12)) & "."
                    n += r(n + 12) + 1
                End While
                requestedHost = requestedHost.Substring(0, requestedHost.Length - 1)

                WriteLine(GetTime() & "Client requesting : " & requestedHost)

                If mustLog Then File.AppendAllText(log, GetTime() & "Client requesting : " & requestedHost & vbCrLf)

                ReDim rr(511)

                s = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                s.ReceiveTimeout = 2000
                s.SendTimeout = 2000
                s.Connect(defaultDNSServer, 53)
                s.Send(r, lngRcv, SocketFlags.None)
                lngSnd = s.Receive(rr, SocketFlags.None)

                ReDim Preserve rr(lngSnd)

                If mustLog Then File.AppendAllText(log, "Real DNS server's answer : " & vbCrLf & _
                                                        Encoding.ASCII.GetString(rr, 0, lngSnd) & vbCrLf & vbCrLf, Encoding.ASCII)

                If requestedHost = "gamestats2.gs.nintendowifi.net" Then
                    If IsLocalIP(CType(rem_ep, IPEndPoint).Address.ToString()) AndAlso (localOnly OrElse useAutoIPSwitching) AndAlso (Not noLocal) Then
                        spoofedIP = localIP
                        spoofedIP_bytes = localIP_bytes
                        spoofTextColor = ConsoleColor.Yellow
                    Else
                        spoofedIP = fakeIP
                        spoofedIP_bytes = fakeIP_bytes
                        spoofTextColor = ConsoleColor.Green
                    End If

                    Array.Copy(spoofedIP_bytes, 0, rr, &H3C, 4)

                    ForegroundColor = spoofTextColor
                    WriteLine(GetTime() & "Spoofing " & requestedHost & " -> " & spoofedIP)
                    ResetColor()

                    If mustLog Then File.AppendAllText(log, GetTime() & "Spoofing : " & requestedHost & " -> " & spoofedIP & vbCrLf)
                End If

                str_rr = Encoding.ASCII.GetString(rr, 0, lngSnd)

                dnsserv.SendTo(rr, rr.Length, SocketFlags.None, rem_ep)
                WriteLine(GetTime() & "Data sent to : " & CType(rem_ep, IPEndPoint).Address.ToString())

                If mustLog Then File.AppendAllText(log, "Data sent to : " & CType(rem_ep, IPEndPoint).ToString() & vbCrLf & _
                                                        str_rr & vbCrLf, Encoding.ASCII)
                If mustLog Then File.AppendAllText(log, GetTime() & "------------------" & vbCrLf & vbCrLf)

                WriteLine()

            Catch ex As ThreadAbortException
                WriteLine(GetTime() & "Got interrupt signal, aborting...")
                If mustLog Then File.AppendAllText(log, GetTime() & "Got interrupt signal, aborting..." & vbCrLf)

            Catch ex As Exception
                ForegroundColor = ConsoleColor.Red
                WriteLine(GetTime() & "Error : " & ex.Message)
                ResetColor()
                If mustLog Then File.AppendAllText(log, GetTime() & "Error : " & ex.Message & vbCrLf)
            End Try
        End While
    End Sub

    Private Sub showHelp()
        WriteLine("Usage : DNS_Server [public_IP] [/local:<local_IP>] [/dns:<DNS_IP>] [/auto]")
        WriteLine("                   [/localonly | /nolocal] [/log]")
        WriteLine()
        WriteLine("  public_IP     Public (external) IP address to use.")
        WriteLine("                Must be a valid IP address (e.g. 123.45.67.89).")
        WriteLine("                This parameter is ignored if /localonly is specified.")
        WriteLine("  local_IP      Local (internal, private) IP address to use.")
        WriteLine("                Must be a valid IP address (e.g. 192.168.1.2).")
        WriteLine("                This parameter is ignored if /nolocal is specified.")
        WriteLine("  DNS_IP        IP address of the real DNS server used to perform DNS queries.")
        WriteLine("                The default value can be changed in 'DNS_Server.exe.config'.")
        WriteLine("  /auto         If this flag is set, the program will try and find both public")
        WriteLine("                and private IPs automatically.")
        WriteLine("                If, for any reason, one or both of the operations failed,")
        WriteLine("                you would be prompted to give the missing IP address(es).")
        WriteLine("                This option enables automatic public/private IP switching.")
        WriteLine("                If used with /localonly, the program won't try and find a")
        WriteLine("                public IP.")
        WriteLine("                Similarly, with /nolocal, only the public IP will be fetched.")
        WriteLine("  /localonly    When used, this parameter will make the program use only the")
        WriteLine("                internal IP, and disables autoswitching between public and")
        WriteLine("                private IPs.")
        WriteLine("  /nolocal      The opposite of /localonly : only the public IP will be used.")
        WriteLine("  /log          If set, the program will log every request it receives and what")
        WriteLine("                it sends to the client, including raw DNS-queries packets.")
        WriteLine("  /?, --help    Shows this help screen ('?', '-h' and '-?' also work).")
        WriteLine()
        WriteLine("Every parameter is case-insensitive, and can be set using prefixes '/', '-' and")
        WriteLine("'--' (e.g. '-lOcAl:192.168.1.2', '--DNS:8.8.8.8', '-Auto', '/LOG', etc.).")

    End Sub

    Private Function IsIPv4(ByVal ip As String) As Boolean
        Dim rIP As Regex = New Regex("^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
        Return rIP.IsMatch(ip)
    End Function

    Private Function GetTime() As String
        Return "[" & Now.ToString("dd/MM/yy HH:mm:ss") & "] "
    End Function

    Private Function DidUserSayYes(Optional ByVal prompt As String = "") As Boolean
        If prompt <> "" Then
            Write(prompt & " [y/n] ")
        End If

        Dim keyChar As Char

        Do
            keyChar = ReadKey(True).KeyChar
        Loop Until New Char() {"y", "n"}.Contains(Char.ToLower(keyChar))

        WriteLine(keyChar)

        Return Char.ToLower(keyChar) = "y"
    End Function

    Private Function IsLocalIP(ByVal ip As String) As Boolean
        'Private IP ranges are :
        '192.168.0.0 - 192.168.255.255
        '172.16.0.0 - 172.31.255.255
        '10.0.0.0 - 10.255.255.255
        With ip
            Return .StartsWith("192.168.") _
                   OrElse .StartsWith("10.") _
                   OrElse (.StartsWith("172.") _
                           AndAlso (.Split(".")(1) >= 16 _
                                    AndAlso .Split(".")(1) < 32))
        End With
    End Function

    Private Function IsArg(ByVal givenArg As String, ByVal wantedArg As String) As Boolean
        Dim validArgs As String() = New String() {"/" & wantedArg, "-" & wantedArg, "--" & wantedArg}

        Return validArgs.Contains(givenArg.ToLower())
    End Function

End Module
