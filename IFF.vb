'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Environment
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

'This module contains IFF related procedures.
Public Module IFFModule
   'This structure defines an IFF record.
   Public Structure IFFRecordStr
      Public Data() As Byte         'Defines an iff record's data.
      Public Identifier As String   'Defines an IFF record's identifier.
      Public Offset As Integer      'Defines an IFF record's offset within its file.
      Public Size As Integer        'Defines an IFF record's size.
   End Structure

   'This structure defines the LBM image information.
   Public Structure IFFFileStr
      Public IFFFileSize As Integer               'Defines the LBM image file's size.
      Public IFFIdentifier As String              'Defines the IFF identifier.
      Public IFFRecords As List(Of IFFRecordStr)  'Defines the list of IFF records in the LBM image file.
      Public IFFType As String                    'Defines the IFF type.
      Public Path As String                       'Defines the LBM image's path.
   End Structure

   Private Const IFF_IDENTIFIER As String = "FORM"  'Defines the IFF identifier expected of all interchange format files.

   'This procedure displays the current IFF file's contents.
   Public Sub DisplayIFFFile(DataBox As textbox)
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
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure loads the specified IFF file and manages its data.
   Public Function IFFFile(Optional IFFFilePath As String = Nothing) As IFFFileStr
      Try
         Static CurrentIFFFile As New IFFFileStr With {.IFFFileSize = &H0%, .IFFIdentifier = Nothing, .IFFRecords = New List(Of IFFRecordStr), .IFFType = Nothing, .Path = Nothing}

         If Not IFFFilePath = Nothing Then
            CurrentIFFFile = New IFFFileStr With {.IFFFileSize = &H0%, .IFFIdentifier = Nothing, .IFFRecords = New List(Of IFFRecordStr), .IFFType = Nothing, .Path = Nothing}

            With CurrentIFFFile
               Using DataStream As New BinaryReader(New MemoryStream(File.ReadAllBytes(IFFFilePath)))
                  .IFFIdentifier = DataStream.ReadChars(&H4%)
                  .IFFFileSize = NumberFromBytes(DataStream.ReadBytes(&H4%))
                  .IFFRecords = New List(Of IFFRecordStr)
                  .IFFType = DataStream.ReadChars(&H4%)

                  Do While DataStream.BaseStream.Position < DataStream.BaseStream.Length - &H1%
                     .IFFRecords.Add(New IFFRecordStr With {.Offset = CInt(DataStream.BaseStream.Position), .Identifier = DataStream.ReadChars(&H4%), .Size = NumberFromBytes(DataStream.ReadBytes(&H4%)), .Data = DataStream.ReadBytes(.Size)})
                  Loop
               End Using

               .Path = IFFFilePath
            End With

            If Not CurrentIFFFile.IFFIdentifier = IFF_IDENTIFIER Then
               MessageBox.Show($"The file does not contain the expected ""{IFF_IDENTIFIER }"" identifier.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
         End If

         Return CurrentIFFFile
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
