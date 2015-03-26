Module Module1
    '******************************************
    'Автор: Шац Юлия.
    '******************************************
    'Редакция от 28.11.2013.
    '******************************************
    'Производит выводт первых N простых чисел.
    '******************************************
    Sub Main()
        Dim N As Integer

        Console.Write("Введите натуральное число N: ")
        N = Console.ReadLine()

        Dim simples As Integer()
        simples = GetFirstSimples(N)
        For Each simple In simples
            Console.WriteLine("Простое число: {0}", simple)
        Next

        Console.ReadLine()

    End Sub

    'Функция проверяет, является ли число простым.
    Function IsSimple(ByVal valueInt As Integer, ByVal simples As Integer()) As Boolean
        Dim result As Boolean = True

        Dim i As Integer = 0
        Dim value As Single
        value = valueInt

        Do While i < simples.Length And simples(i) > 0
            If value Mod simples(i) = 0.0 Then
                result = False
                Exit Do
            End If
            i += 1
        Loop

        Return result
    End Function

    'Функция производит запись всех простых чисел до уазанного значения.
    Function GetFirstSimples(ByVal count As Integer) As Integer()
        Dim simples As Integer()
        Dim base, simpleIndex As Integer
        simples = New Integer(count - 1) {}

        base = 2
        simpleIndex = 0
        Do While simpleIndex < simples.Length
            If IsSimple(base, simples) Then
                simples(simpleIndex) = base
                simpleIndex += 1
            End If
            base += 1
        Loop

        Return simples
    End Function
End Module
