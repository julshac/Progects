Module Module1

    Public Structure SRobber
        Public RobberName As String
        Public Gender As Boolean
        Public Age As UShort
        Public Value As UInteger
    End Structure

    Sub Main()
        Dim menOrWoman As String
        Dim murdurers(10) As SRobber
        Dim names() As String = {"Пахан", "Торпеда", "Трус", "Шнур", "Щука", "Балбес", "Духарь", "Доцент", "Кайт", "Док", "Бывалый"}
        Dim r As New Random

        For i = 0 To murdurers.Length - 1
            murdurers(i).RobberName = names(i)
            murdurers(i).Gender = r.Next(-1, 1)
            murdurers(i).Age = r.Next(13, 75)
            murdurers(i).Value = r.Next(-1, 1000000000)
        Next

        Do
            Console.Write("Введите пол искомого грабителя (0 - М, 1 - Ж): ")
            menOrWoman = Console.ReadLine()
            If IsNumeric(menOrWoman) = True Then
                If menOrWoman = 0 Or menOrWoman = 1 Then
                    If FindRobber(menOrWoman, murdurers) > -1 Then
                        Console.WriteLine("Искомый грабитель: {0}: {1}" & vbCrLf & "Пол: {2}" & vbCrLf & "Возраст {3}" & vbCrLf & "Размер ущерба {4}", FindRobber(menOrWoman, murdurers), murdurers(FindRobber(menOrWoman, murdurers)).RobberName, murdurers(FindRobber(menOrWoman, murdurers)).Gender, murdurers(FindRobber(menOrWoman, murdurers)).Age, murdurers(FindRobber(menOrWoman, murdurers)).Value)
                        Exit Do
                    Else : Console.WriteLine("Нет данных, удовлетворяющих критерию поиска")
                    End If
                Else : Console.WriteLine("Пол введен неверно")
                End If
            Else
                Console.WriteLine("Пол введен неверно")
            End If
        Loop

        Console.ReadLine()

    End Sub

    Function FindRobber(ByVal gender As Boolean, ByVal arr() As SRobber) As Integer
        Dim maxValue As UInteger = 0
        Dim resultIndex As Integer = -1

        For index = 0 To arr.Length - 1
            If arr(index).Gender = gender AndAlso maxValue <= arr(index).Value Then
                resultIndex = index
            End If
        Next
        Return resultIndex
    End Function

End Module
