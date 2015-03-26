Module Module1

    Sub Main()
        Dim M, N, K As Integer
        Dim e, f, j, i As Integer

        'Начальное условие 
        Do
            Console.WriteLine("Введите количество рядов ромбов (1 - 5): ")
            N = Console.ReadLine()
        Loop Until N >= 1 And N <= 5

        Do
            Console.WriteLine("Введите количество ромбов в ряду (1 - 5): ")
            M = Console.ReadLine()
        Loop Until M >= 1 And M <= 5

        Do
            Console.WriteLine("Введите размер ромба (1 - 5): ")
            K = Console.ReadLine()
        Loop Until K >= 1 And K <= 5

        For e = 1 To N
            For j = 1 To 2 * K - 1
                Console.WriteLine()
                For f = 1 To M
                    For i = 1 To 2 * K - 1
                        If j < K + 1 Then
                            If i >= K - j + 1 And i <= K + j - 1 Then
                                Console.Write("@")
                            Else
                                Console.Write(" ")
                            End If
                        Else
                            If i >= (j - K) + 1 And i <= 2 * K - (j - K) - 1 Then
                                Console.Write("@")
                            Else
                                Console.Write(" ")
                            End If
                        End If
                    Next
                    If f < M Then
                        Console.Write(" ")
                    End If
                Next
            Next

            Console.WriteLine()
        Next
        Console.ReadLine()
    End Sub

End Module
