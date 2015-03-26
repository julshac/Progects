Module Module1
    Public discCounts(2) As Integer
    Public moves(,) As Integer
    Public movesIndex As Integer
    Sub Main()
        Dim num As Integer
        Console.Write("Введите количество колец: ")
        num = Console.ReadLine()

        NumDiscs(num)
        moves = GetMoves()
      
        Console.ReadLine()
    End Sub

    Public Sub NumDiscs(ByVal numDiscs As Integer)

        discCounts(0) = numDiscs
        discCounts(1) = 0
        discCounts(2) = 1

        ReDim moves(2 ^ numDiscs - 2, 1)
        movesIndex = 0
    End Sub

    Public Function GetMoves() As Integer(,)
        Move(0, 1, 2, discCounts(0))
        Return moves
    End Function

    Private Sub Move(ByVal sourceCircle As Integer, ByVal destCircle As Integer, ByVal tempCircle As Integer, ByVal discsToMove As Integer)

        If discsToMove > 0 Then
            Move(sourceCircle, tempCircle, destCircle, discsToMove - 1)
            Console.WriteLine("Переместить диск со стержня {0} на стержень {1}", sourceCircle, destCircle)
            Move(tempCircle, destCircle, sourceCircle, discsToMove - 1)
        End If

    End Sub
End Module
