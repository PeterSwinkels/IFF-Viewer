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
            DisplayIFFFile(DataBox)
         End If

         Me.Text = ProgramInformation()

         ToolTip.SetToolTip(DataBox, "Drag an IFF file into this window to display its contents.")
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to load the file dropped into the image box.
   Private Sub DataBox_DragDrop(sender As Object, e As DragEventArgs) Handles DataBox.DragDrop
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            IFFFile(IFFFilePath:=DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).First)
            DisplayIFFFile(DataBox)
         End If
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure handles objects being dragged into the data box.
   Private Sub DataBox_DragEnter(sender As Object, e As DragEventArgs) Handles DataBox.DragEnter
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.All
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure displays informationa about this program.
   Private Sub InformationMenu_Click(sender As Object, e As EventArgs) Handles InformationMenu.Click
      Try
         MessageBox.Show(My.Application.Info.Description, ProgramInformation(), MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure displays the open file dialog box.
   Private Sub OpenFileMenu_Click(sender As Object, e As EventArgs) Handles OpenFileMenu.Click
      Try
         With New OpenFileDialog()
            If .ShowDialog() = DialogResult.OK Then
               IFFFile(IFFFilePath:= .FileName)
               DisplayIFFFile(DataBox)
            End If
         End With
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure closes this program's main window.
   Private Sub QuitMenu_Click(sender As Object, e As EventArgs) Handles QuitMenu.Click
      Try
         Me.Close()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub
End Class
