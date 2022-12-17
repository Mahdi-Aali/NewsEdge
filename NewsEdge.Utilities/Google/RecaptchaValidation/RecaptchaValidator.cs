using NewsEdge.DTOs.Google;
using Newtonsoft.Json;

namespace NewsEdge.Utilities.Google.RecaptchaValidation;

public static class RecaptchaValidator
{
    public static async Task<bool> IsValidAsync(string userCaptchaKey)
    {
        using (HttpClient client = new())
        {
            string secretKey = "6LcGpR8jAAAAABrpKaXbV47Q5EPdtWHT07pCBP3K";
            HttpResponseMessage response = await client
                .PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={userCaptchaKey}", null);

            RecapthcaResult result = JsonConvert.DeserializeObject<RecapthcaResult>(await response.Content.ReadAsStringAsync()) ?? new();

            return result.Success;
        }
    }
}
