Namespace TalkingClock
    Public Class Clock
        Public Shared Function TellTime(ByVal strTime As String) As String

            Dim humanFriendlyTime As String
            Dim tellMinutes As String = String.Empty
            Dim tellBetween As String = String.Empty
            Dim tellHours As String = String.Empty
            Dim tellAfter As String = String.Empty
            Dim timeStamp? As DateTime

            Try

                If String.IsNullOrEmpty(strTime) Then
                    timeStamp = DateTime.Now
                Else
                    timeStamp = Convert.ToDateTime(Sanitize(strTime))
                End If

                If timeStamp IsNot Nothing Then
                    Dim timeHours As Integer = timeStamp.Value.Hour
                    Dim timeMinutes As Integer = timeStamp.Value.Minute

                    If timeMinutes > 0 And timeMinutes <= 30 Then
                        tellBetween = "past"
                    ElseIf timeMinutes > 30 Then
                        tellBetween = "to"

                        If timeHours < 24 Then
                            timeHours += 1
                        Else
                            timeHours = 1
                        End If
                    End If

                    If timeHours > 12 And timeHours < 24 Then timeHours -= 12
                    tellHours = DetermineHours(timeHours)
                    tellMinutes = DetermineMinutes(timeMinutes)

                    If timeMinutes = 0 And timeHours <> 0 Then tellAfter = "o'clock"
                    humanFriendlyTime = $"{tellMinutes} {tellBetween} {tellHours} {tellAfter}"
                Else
                    humanFriendlyTime = "Unknown"
                End If

            Catch ex As Exception
                humanFriendlyTime = "Unknown"
            End Try

            Return Capitalize(humanFriendlyTime)
        End Function

        Private Shared Function Capitalize(ByVal sentence As String) As String

            sentence = sentence.Trim()
            Return Char.ToUpper(sentence.First()) & sentence.Substring(1).ToLower()

        End Function

        Private Shared Function Sanitize(ByVal strTime As String) As String

            strTime = strTime.Trim().Replace(".", ":")
            Dim alpha As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz /\\[]@#,;'*+-!£$%^&*(){}<>?|`¬~_=".ToCharArray()
            Return New String(strTime.Where(Function(c) Not alpha.Contains(c)).ToArray())

        End Function

        Private Shared Function DetermineHours(ByVal timeHours As Integer) As String

            Dim hourUnits As String() = {"midnight", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}

            If timeHours = 24 Then
                Return hourUnits(0)
            Else
                Return hourUnits(timeHours)
            End If

        End Function

        Private Shared Function DetermineMinutes(ByVal timeMinutes As Integer) As String

            Dim minuteUnits As String() = {String.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "quarter", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four", "twenty-five", "twenty-six", "twenty-seven", "twenty-eight", "twenty-nine", "half"}

            If timeMinutes <= 30 Then
                Return minuteUnits(timeMinutes)
            Else
                timeMinutes = 60 - timeMinutes
                Return minuteUnits(timeMinutes)
            End If

        End Function

    End Class
End Namespace
