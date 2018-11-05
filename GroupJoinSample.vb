Class Ts1
    Public Property a1 As Integer
    Public Property a2 As Integer
    Public Property a3 As Integer
End Class

Class Ts2
    Public Property b1 As Integer
    Public Property b2 As Integer
    Public Property b3 As Integer
End Class


Module Module1

    Sub Main()

        Dim lst1 As New List(Of Ts1)
        Dim lst2 As New List(Of Ts2)

        For i = 1 To 10
            Dim buff1 As New Ts1
            buff1.a1 = i
            buff1.a2 = i * 10
            buff1.a3 = i * 20
            lst1.Add(buff1)

            For j = 1 To 10
                Dim buff2 As New Ts2

                buff2.b1 = i
                buff2.b2 = j
                buff2.b3 = j * 10
                lst2.Add(buff2)
            Next
        Next

        Dim buff12 As New Ts1
        buff12.a1 = 100
        buff12.a2 = 100 * 10
        buff12.a3 = 100 * 20
        lst1.Add(buff12)

        Dim hoge = lst1.GroupJoin(lst2, Function(x) x.a1,
                                        Function(y) y.b1,
                                        Function(x, y) New With {
                                            .Main = x,
                                            .Sub = y
                                        }).
                        SelectMany(Function(s) s.Sub.DefaultIfEmpty(),
                                   Function(s, t) New With {
                                            .test1 = s.Main.a1,
                                            .test2 = s.Sub.Count(),
                                            .test3 = t?.b2,
                                            .test4 = t?.b3
                                   }).ToList()

        hoge.ToList.ForEach(Sub(x) Debug.WriteLine($"{x.test1},{x.test2},{x.test3},{x.test4}"))
    End Sub

End Module
