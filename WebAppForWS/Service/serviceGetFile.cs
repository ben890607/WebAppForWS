using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// serviceGetFile 的摘要描述
/// </summary>
public class serviceGetFile
{
    public serviceGetFile()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public byte[] GetImage(string requestFileName)
    {
        ///得到伺服器端的一個圖片
        ///如果你自己測試，注意修改下面的實際物理路徑
        if (requestFileName == null || requestFileName == "")
            return getBinaryFile(@"C:\inetpub\ECOB\身份證樣張-正面.jpg");
        else
            return getBinaryFile(@"C:\inetpub\ECOB\" + requestFileName);
    }
    ///<summary>
    ///getBinaryFile：返回所給檔案路徑的位元組陣列。
    ///</summary>
    ///<paramname=”filename”></param>
    ///<returns></returns>
    public byte[] getBinaryFile(string filename)
    {
        if (File.Exists(filename))
        {
            try
            {
                ///開啟現有檔案以進行讀取。
                FileStream s = File.OpenRead(filename);
                return ConvertStreamToByteBuffer(s);
            }
            catch (Exception e)
            {
                return new byte[0];
            }
        }
        else
        {
            return new byte[0];
        }
    }
    ///<summary>
    ///ConvertStreamToByteBuffer：把給定的檔案流轉換為二進位制位元組陣列。
    ///</summary>
    ///<paramname=”theStream”></param>
    ///<returns></returns>
    public byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
    {
        int b1;
        System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
        while ((b1 = theStream.ReadByte()) != -1)
        {
            tempStream.WriteByte(((byte)b1));
        }
        return tempStream.ToArray();
    }

}