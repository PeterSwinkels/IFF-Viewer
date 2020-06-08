'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.IO

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

   'This procedure loads the specified IFF file and manages its data.
   Public Function IFFFile(Optional IFFFilePath As String = Nothing) As IFFFileStr
      Try
         Static CurrentIFFFile As New IFFFileStr

         If Not IFFFilePath = Nothing Then
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
         End If

         Return CurrentIFFFile
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
