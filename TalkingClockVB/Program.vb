Module Program
    Sub Main(args As String())

        Console.WriteLine()

        If args.Length = 0 Then
            Console.WriteLine(TalkingClock.Clock.TellTime(String.Empty))
        Else
            Console.WriteLine(TalkingClock.Clock.TellTime(args(0)))
        End If

        Console.WriteLine()
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()

    End Sub
End Module
