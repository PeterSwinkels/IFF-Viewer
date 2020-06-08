'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Drawing
Imports System.Environment
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

'This module contains this program's interface.
Public Class InterfaceWindow
   'This procedure initializes this window.
   Public Sub New()
      Try
         InitializeComponent()

         My.Application.ChangeCulture("en-US")

         With My.Computer.Screen.WorkingArea
            Me.Size = New size(CInt(.Width / 1.1), CInt(.Height / 1.1))
         End With

         If GetCommandLineArgs().Count > 1 Then
            IFFFile(IFFFilePath:=GetCommandLineArgs().Last)
            DisplayIFFFile()
         End If

         Me.Text = ProgramInformation()

         ToolTip.SetToolTip(DataBox, "Drag an IFF file into this window to display its contents.")
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to load the file dropped into the image box.
   Private Sub DataBox_DragDrop(sender As Object, e As DragEventArgs) Handles DataBox.DragDrop
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            IFFFile(IFFFilePath:=DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).First)
            DisplayIFFFile()
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles objects being dragged into the data box.
   Private Sub DataBox_DragEnter(sender As Object, e As DragEventArgs) Handles DataBox.DragEnter
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.All
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure displays the current IFF file's contents.
   Private Sub DisplayIFFFile()
      Try
         With New StringBuilder
            .Append($"Path: {IFFFile().Path}{NewLine}")
            .Append($"IFF file size: {IFFFile().IFFFileSize} byte(s){NewLine}")
            .Append($"IFF identifier: {IFFFile().IFFIdentifier}{NewLine}")
            .Append($"IFF type: {IFFFile().IFFType}{NewLine}")
            .Append(NewLine)
            For Each IFFRecord As IFFRecordStr In IFFFile().IFFRecords
               .Append($"Identifier: {IFFRecord.Identifier}{NewLine}")
               .Append($"Offset: {IFFRecord.Offset}{NewLine}")
               .Append($"Size: {IFFRecord.Size}  byte(s){NewLine}")
               .Append($"Data:{NewLine}")
               Array.ForEach(IFFRecord.Data, Sub(ByteV As Byte) .Append($"{$"{ByteV:X2}",-3}"))
               .Append(NewLine)
               .Append(NewLine)
            Next IFFRecord

            DataBox.Text = .ToString()
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub
End Class
