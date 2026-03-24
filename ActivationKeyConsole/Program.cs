


using ActivationKeyConsole.Domain;
using ActivationKeyConsole.Helpers;
using Cashier.Helpers.Helpers;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

BeginProcess:;

Console.WriteLine($"Helllo Sir , Choose An Operation to do ");
Console.WriteLine($"1 Encryption , 2 Decryption , 3 Create Key , 4 Read Key ");
try
{
int resultInt = Convert.ToInt32(Console.ReadLine());
    string resultString = "";
    switch (resultInt)
    {
        case 1 :
            Console.WriteLine($"Enter Value That You Want to Encrypt");
            resultString = Console.ReadLine().Trim();
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine( EncryptText.EncryptPlainText(resultString));
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            break;
        case 2 :
            Console.WriteLine($"Enter Value That You Want to Decrypt");
            resultString = Console.ReadLine().Trim();
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(DecryptText.DecryptPlainText(resultString).Result);
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            break;
        case 3 :
            var model = new AppSettingClass();
            Console.WriteLine($"Insert System Allowed Devices , Default : ({model.SystemAllowedDevices} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            model.SystemAllowedDevices = string.IsNullOrEmpty(resultString)?model.SystemAllowedDevices : resultString;
            Console.WriteLine($"Value Is ::: {model.SystemAllowedDevices}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Insert System Expire Date , Default : ({model.SystemExpireDate} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            model.SystemExpireDate = string.IsNullOrEmpty(resultString)?model.SystemExpireDate : resultString;
            Console.WriteLine($"Value Is ::: {model.SystemExpireDate}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Insert Receipt Footer  , Default : ({model.ReceiptFooterHeader} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            model.ReceiptFooterHeader = string.IsNullOrEmpty(resultString)?model.ReceiptFooterHeader : resultString;
            Console.WriteLine($"Value Is ::: {model.ReceiptFooterHeader}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Insert Maximum Number Of Users  , Default : ({model.MaximumNumberOfUsers} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            resultInt = string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt32(resultString);
            model.MaximumNumberOfUsers = resultInt == 0 ?model.MaximumNumberOfUsers : resultInt;
            Console.WriteLine($"Value Is ::: {model.MaximumNumberOfUsers}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Insert Server Time Differences  , Default : ({model.ServerTimeDifference} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            resultInt = string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt32(resultString);
            model.ServerTimeDifference = resultInt == 0 ?model.ServerTimeDifference : resultInt;
            Console.WriteLine($"Value Is ::: {model.ServerTimeDifference}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Insert Uta Time Difference  , Default : ({model.UtaTimeDifference} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            resultInt = string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt32(resultString); model.UtaTimeDifference = resultInt == 0 ?model.UtaTimeDifference : resultInt;
            Console.WriteLine($"Value Is ::: {model.UtaTimeDifference}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine($"Insert ReLogin After How Many Hour  , Default : ({model.JWTExpiredTimeInHour} ) Press Enter To Take Default Value");
            resultString = Console.ReadLine().Trim();
            resultInt = string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt32(resultString); model.JWTExpiredTimeInHour = resultInt == 0 ?model.JWTExpiredTimeInHour : resultInt;
            Console.WriteLine($"Value Is ::: {model.JWTExpiredTimeInHour}");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            string Json = JsonConvert.SerializeObject(model);
            Console.WriteLine("Json Result :::::::::::::::::::");
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(EncryptText.EncryptPlainText(Json));
            Console.WriteLine( "----------------------------------------------------------------------------------------------------------------------------");

            break;
        case 4 :
            Console.WriteLine($"Enter Activation Key  That You Want to Read It");
            var reader = Console.ReadLine().Trim();
            var hashedModel = JsonConvert.DeserializeObject<AppSettingClass>(DecryptText.DecryptPlainText(reader).Result);
            Console.WriteLine(
                $@"
System Allowed Devices : ({hashedModel.SystemAllowedDevices}) 
System Expire Date : ({hashedModel.SystemExpireDate}) 
Receipt Footer Header: ({hashedModel.ReceiptFooterHeader}) 
Maximum Number Of Users : ({hashedModel.MaximumNumberOfUsers}) 
ServerTimeDifference : ({hashedModel.ServerTimeDifference}) 
Uta Time Difference : ({hashedModel.UtaTimeDifference}) 
Insert ReLogin After How Many Hour   : ({hashedModel.JWTExpiredTimeInHour}) 
"
                );
            break;
       default :
            Console.WriteLine($"Not Recognized Input Please Try Again");
            goto BeginProcess;
            break;
    }


}catch(Exception ex)
{
    Console.WriteLine($"Error While Executing :::{ex.Message} {ex.InnerException?.Message}" );
    goto BeginProcess;
}
Console.WriteLine($":: End Of Program ::");
goto BeginProcess;
