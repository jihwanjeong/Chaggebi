
public class CGBData
{
    //������ ���� ����
    public bool isPlaced { get; set; } = false;
    public string name { get; set; } = "������";
    public string description { get; set; }
    public int age { get; set; } = 1; //��ȭ�ܰ�
    public enum skins { baby, strawberry }
    public skins skin { get; set; } //����
    public enum colors { green, yellow, red, brown }
    public colors bodyColor { get; set; } //����

    public int mouth { get; set; }
    public int brow { get; set; }

    public void UpdateAppearance(CGBData newCGB)
    {
        isPlaced = newCGB.isPlaced;
        name = newCGB.name;
        description = newCGB.description;
        age = newCGB.age;
        skin = newCGB.skin;
        bodyColor = newCGB.bodyColor;
        mouth = newCGB.mouth;
        brow = newCGB.brow;
    }
}
