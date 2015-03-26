Module Module2

    'Редакция от 28.11.2013.
    '********************************************************************************************************************************************
    'Высчитывает сумму цифр исходного числа, а затем сумму цифр полученной суммы, до тех пор, пока в ответе не получится значение из одной цифры.
    '********************************************************************************************************************************************

    Sub Main()
        Dim figure As Integer

        Console.Write("Введите число: ")
        figure = Console.ReadLine()

        Console.WriteLine("Полученное число: {0}", SumNumbers(figure))
        Console.ReadLine()

    End Sub

    'Функция выподянет суммирование цифр в исходном и последующих числах.
    Function SumNumbers(ByVal value As Integer) As Integer
        Dim result As Integer
        Dim curValue, Sum As Integer

        If value > 0 Then
            curValue = value
            Do While curValue > 0
                Sum = Sum + curValue Mod 10
                curValue = curValue \ 10
            Loop
            If Sum > 9 Then
                result = SumNumbers(Sum)
            Else
                result = Sum
            End If
        End If

        Return result
    End Function
End Module
