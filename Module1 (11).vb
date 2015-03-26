Module Module1

    Sub Main()
        Dim minValue, maxValue As Integer
        Dim vMin, vMax, guessNumber, vHalf As Single
        Dim answer As String

        Console.WriteLine("Задумайте четырехзначное число")
        maxValue = 9999
        minValue = 1000
        vHalf = Math.Round((maxValue - minValue) / 2)
        vMin = minValue
        vMax = maxValue

        'Находим загаданное число, используя метод половинного деления
        Do
            Console.WriteLine("Введите [Да], если загаданное вами число больше {0}?", Math.Round(vHalf))
            answer = Console.ReadLine()
            guessNumber = vHalf
            If answer.ToUpper = "ДА" Then
                vMin = vHalf + 1
                vHalf = vMin + (vMax - vHalf) / 2
            Else
                vMax = vHalf
                vHalf = vMin + (vHalf - vMin) / 2
            End If

        Loop While Math.Round(guessNumber) <> Math.Round(vHalf)

        'Округляем искомое число до целого
        guessNumber = Math.Round(guessNumber)

        'Выводим результат пользователю
        Console.WriteLine("Вы задумали число: {0}", guessNumber)

        Console.ReadLine()
    End Sub

End Module
