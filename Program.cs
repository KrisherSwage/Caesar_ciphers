using System;

public class CaesarCipher
{
    
    const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; //Символы русской азбуки
    

    private string CodeEncode(string text, int k) //Метод с алгоритмом шифровки/дешифровки
    {
        
        var fullAlfabet = alfabet + alfabet.ToLower(); //Добавляем в алфавит маленькие буквы
        var letterQty = fullAlfabet.Length; //Длина алфавита с маленькими и заглавными буквами
        var retVal = ""; //Поле для отшифрованного алфавита
        for (int i = 0; i < text.Length; i++) //Цикл, который будет идти, пока не кончится введенная фраза
        {
            var c = text[i]; 
            var index = fullAlfabet.IndexOf(c); //Во всем алфавите ищет номер первого вхождения i-той буквы введенной фразы
            if (index < 0)
            {
                //если символ не найден, то добавляем его в неизменном виде
                retVal += c.ToString();
            }
            else
            {
                var codeIndex = (letterQty + index + k) % letterQty; //Индекс измененной буквы
                retVal += fullAlfabet[codeIndex]; //Составление измененной фразы из букв с измененным индексом
            }
        }

        return retVal;
    }

    //шифрование текста
    public string Encrypt(string plainMessage, int key) => CodeEncode(plainMessage, key); //Метод, который потом вернет нужное значение(зашифрованную строку)
        

    //дешифрование текста
    public string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);
       
}

class Program
{
    static void Main(string[] args)
    {
        var cipher = new CaesarCipher(); //Объект класса

        Console.Write("Введите текст: ");
        var message = Console.ReadLine();
        Console.Write("Введите ключ: ");
        var secretKey = Convert.ToInt32(Console.ReadLine());

        var encryptedText = cipher.Encrypt(message, secretKey);

        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
        Console.WriteLine("Расшифрованное сообщение: {0}", cipher.Decrypt(encryptedText, secretKey));
        Console.ReadLine();
    }
}