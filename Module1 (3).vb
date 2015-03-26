Module Module1

    Sub Main()
        Dim month, day As Integer
        Dim monthStr, dayStr As String

        'Проверка корректности ввода целого числа (для месяца)
        Console.Write("Введите номер месяца: ")
        monthStr = Console.ReadLine()
        Do While (Not Int32.TryParse(monthStr, month))
            Console.Write("Введите корректный номер месяца (номер месяца должен быть целым числом) : ")
            monthStr = Console.ReadLine()
        Loop

        'Проверка корректности ввода целого числа (для дня)
        Console.Write("Введите номер дня: ")
        dayStr = Console.ReadLine()
        Do While (Not Int32.TryParse(dayStr, day))
            Console.Write("Введите корректный номер дня (номер дня должен быть целым числом) : ")
            dayStr = Console.ReadLine()
        Loop

        If month >= 1 And month <= 12 Then
            Select Case month
                Case 1, 3, 5, 7, 8, 10
                    If day >= 1 And day <= 31 Then
                        Console.WriteLine("Вы ввели верные номера месяца и дня.")
                    Else : Console.WriteLine("Вы ввели некорректный номер дня.{0}В месяце [{1}] может быть от 1 до 31 дня.", Environment.NewLine, month)
                    End If
                Case 4, 6, 8, 11, 12
                    If day >= 1 And day <= 30 Then
                        Console.WriteLine("Вы ввели верные номера месяца и дня.")
                    Else : Console.WriteLine("Вы ввели некорректный номер дня.{0}В месяце [{1}] может быть от 1 до 30 дней.", Environment.NewLine, month)
                    End If
                Case Else
                    If day >= 1 And day <= 29 Then
                        Console.WriteLine("Вы ввели верные номера месяца и дня.")
                    Else : Console.WriteLine("Вы ввели некорректный номер дня.{0}В месяце [{1}] может быть от 1 до 29 дней.", Environment.NewLine, month)
                    End If
            End Select
        Else : Console.WriteLine("Вы ввели некорректный номер месяца.{0}В году может быть от 1 до 12 месяцев.", Environment.NewLine)
        End If
        Console.ReadLine()

    End Sub

End Module
