'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Convert
Imports System.Text
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module CoreModule
   'This procudure displays any errors that occur.
   Public Sub DisplayError(ExceptionO As Exception)
      Try
         If MessageBox.Show(ExceptionO.ToString(), My.Application.Info.Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.Cancel Then Application.Exit()
      Catch
         InterfaceWindow.Close()
      End Try
   End Sub

   'This procedure converts the specified bytes to a number.
   Public Function NumberFromBytes(Bytes() As Byte) As Integer
      Try
         Dim Hexadecimals As New StringBuilder

         Array.Reverse(Bytes)

         Return BitConverter.ToInt32(Bytes, 0)
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns information about this program.
   Public Function ProgramInformation() As String
      Try
         With My.Application.Info
            Return $"{ .Title} v{ .Version} - by: { .CompanyName} { .Copyright}"
         End With
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
