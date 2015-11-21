using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class FileOptions {
    public string extension { get; set; }
    public ImageFormat format { get; set; }

}




public static class FileController {
    public static FileOptions GetFileOption(FileType ft) {

        FileOptions ret = new FileOptions();
        ret.extension = "." + Enum.GetName(typeof(FileType), ft);

        switch (ft) {
            case FileType.PNG:
                ret.format = ImageFormat.Png;
                break;
            case FileType.JPEG:
                ret.format = ImageFormat.Jpeg;
                break;
            case FileType.GIF:
                ret.format = ImageFormat.Gif;
                break;
            case FileType.Bitmap:
                ret.format = ImageFormat.Bmp;
                break;
            default:
                ret.format = ImageFormat.Jpeg;
                break;
        }

        return ret;

    }

    
    public static void UploadToImgur(string filepath, UploadDataCompletedEventHandler uploadComplete) {

      

        using (WebClient client = new WebClient()) {
            client.Headers.Set(HttpRequestHeader.Authorization, "Client-ID 01a63dbbbc88827");
            byte[] by = File.ReadAllBytes(filepath);

            client.UploadDataCompleted += uploadComplete;

            client.UploadDataAsync(new Uri("https://api.imgur.com/3/image"), "POST", by);
        }


    }




}

public enum FileType {
    PNG,
    JPEG,
    GIF,
    Bitmap
}

public enum AfterUpload {
    Copy_address_to_clipboard,
    Open_browser,
    Nothing
}

public class Data {
    public string id { get; set; }
    public object title { get; set; }
    public object description { get; set; }
    public int datetime { get; set; }
    public string type { get; set; }
    public bool animated { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int size { get; set; }
    public int views { get; set; }
    public int bandwidth { get; set; }
    public object vote { get; set; }
    public bool favorite { get; set; }
    public object nsfw { get; set; }
    public object section { get; set; }
    public object account_url { get; set; }
    public int account_id { get; set; }
    public object comment_preview { get; set; }
    public string deletehash { get; set; }
    public string name { get; set; }
    public string link { get; set; }
}

public class RootObject {
    public Data data { get; set; }
    public bool success { get; set; }
    public int status { get; set; }
}