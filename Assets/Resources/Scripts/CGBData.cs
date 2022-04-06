[System.Serializable]
public class CGBData
{
    //������ ���� ����
    public bool isPlaced { get; set; } = false;
    public int age { get; set; } = 1; //��ȭ�ܰ�
    public string base1 { get; set; } //����(1�ܰ�)
    public string base2 { get; set; } //��Ų(2�ܰ�)
    public enum flavors { none, scent, earthy, sweet, sour } public flavors flavor { get; set; } //��(3�ܰ�)
    public string name { get; set; } = "������";
    public string description { get; set; }

    //public enum skins { baby, strawberry, lemon, butterfly }
    //public skins skin { get; set; } //����
    //public enum colors { green, yellow, red, brown, blue }
    //public colors bodyColor { get; set; } //����

    public int mouth { get; set; }
    public int brow { get; set; }

    public void UpdateAppearance(CGBData newCGB)
    {
        isPlaced = newCGB.isPlaced;
        age = newCGB.age;
        base1 = newCGB.base1;
        base2 = newCGB.base2;
        name = newCGB.name;
        description = newCGB.description;
        //skin = newCGB.skin;
        //bodyColor = newCGB.bodyColor;
        mouth = newCGB.mouth;
        brow = newCGB.brow;
    }
}
