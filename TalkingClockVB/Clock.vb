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
            Dim alpha As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz /\[]@#,;'*+-!£$%^&*(){}~_=".ToCharArray()
            Return New String(strTime.Where(Function(c) Not alpha.Contains(c)).ToArray())
        End Function

        Private Shared Function DetermineHours(ByVal timeHours As Integer) As String
            Dim tellHours As String = String.Empty

            Select Case timeHours
                Case 0
                    tellHours = "midnight"
                Case 1
                    tellHours = "one"
                Case 2
                    tellHours = "two"
                Case 3
                    tellHours = "three"
                Case 4
                    tellHours = "four"
                Case 5
                    tellHours = "five"
                Case 6
                    tellHours = "six"
                Case 7
                    tellHours = "seven"
                Case 8
                    tellHours = "eight"
                Case 9
                    tellHours = "nine"
                Case 10
                    tellHours = "ten"
                Case 11
                    tellHours = "eleven"
                Case 12
                    tellHours = "twelve"
                Case 24
                    tellHours = "midnight"
            End Select

            Return tellHours
        End Function

        Private Shared Function DetermineMinutes(ByVal timeMinutes As Integer) As String

            Dim tellMinutes As String = String.Empty

            Select Case timeMinutes
                Case 1
                    tellMinutes = "one"
                Case 2
                    tellMinutes = "two"
                Case 3
                    tellMinutes = "three"
                Case 4
                    tellMinutes = "four"
                Case 5
                    tellMinutes = "five"
                Case 6
                    tellMinutes = "six"
                Case 7
                    tellMinutes = "seven"
                Case 8
                    tellMinutes = "eight"
                Case 9
                    tellMinutes = "nine"
                Case 10
                    tellMinutes = "ten"
                Case 11
                    tellMinutes = "eleven"
                Case 12
                    tellMinutes = "twelve"
                Case 13
                    tellMinutes = "thirteen"
                Case 14
                    tellMinutes = "fourteen"
                Case 15
                    tellMinutes = "quarter"
                Case 16
                    tellMinutes = "sixteen"
                Case 17
                    tellMinutes = "seventeen"
                Case 18
                    tellMinutes = "eighteen"
                Case 19
                    tellMinutes = "nineteen"
                Case 20
                    tellMinutes = "twenty"
                Case 21
                    tellMinutes = "twenty-one"
                Case 22
                    tellMinutes = "twenty-two"
                Case 23
                    tellMinutes = "twenty-three"
                Case 24
                    tellMinutes = "twenty-four"
                Case 25
                    tellMinutes = "twenty-five"
                Case 26
                    tellMinutes = "twenty-six"
                Case 27
                    tellMinutes = "twenty-seven"
                Case 28
                    tellMinutes = "twenty-eight"
                Case 29
                    tellMinutes = "twenty-nine"
                Case 30
                    tellMinutes = "half"
                Case 31
                    tellMinutes = "twenty-nine"
                Case 32
                    tellMinutes = "twenty-eight"
                Case 33
                    tellMinutes = "twenty-seven"
                Case 34
                    tellMinutes = "twenty-six"
                Case 35
                    tellMinutes = "twenty-five"
                Case 36
                    tellMinutes = "twenty-four"
                Case 37
                    tellMinutes = "twenty-three"
                Case 38
                    tellMinutes = "twenty-two"
                Case 39
                    tellMinutes = "twenty-one"
                Case 40
                    tellMinutes = "twenty"
                Case 41
                    tellMinutes = "nineteen"
                Case 42
                    tellMinutes = "eighteen"
                Case 43
                    tellMinutes = "seventeen"
                Case 44
                    tellMinutes = "sixteen"
                Case 45
                    tellMinutes = "quarter"
                Case 46
                    tellMinutes = "fourteen"
                Case 47
                    tellMinutes = "thirteen"
                Case 48
                    tellMinutes = "twelve"
                Case 49
                    tellMinutes = "eleven"
                Case 50
                    tellMinutes = "ten"
                Case 51
                    tellMinutes = "nine"
                Case 52
                    tellMinutes = "eight"
                Case 53
                    tellMinutes = "seven"
                Case 54
                    tellMinutes = "six"
                Case 55
                    tellMinutes = "five"
                Case 56
                    tellMinutes = "four"
                Case 57
                    tellMinutes = "three"
                Case 58
                    tellMinutes = "two"
                Case 59
                    tellMinutes = "one"
            End Select

            Return tellMinutes
        End Function

    End Class
End Namespace
