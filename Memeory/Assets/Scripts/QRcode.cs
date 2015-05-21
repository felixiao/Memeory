using UnityEngine;
using System.Collections;
using QRCoder;
using UnityEngine.UI;
public class QRcode : MonoBehaviour {
    public QRCodeGenerator qrGenerator;
    public UnityEngine.UI.RawImage QR_RawImage;
    public Text QR_Content;
    public Slider slider;
	// Use this for initialization
	void Start () {
        qrGenerator = new QRCodeGenerator();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GenerateQR()
    {
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(QR_Content.text, (QRCodeGenerator.ECCLevel)((int)slider.value));
        QR_RawImage.texture = qrCode.GetGraphic(18);
    }
    public string ScanQR()
    {

        return "";
    }
}
