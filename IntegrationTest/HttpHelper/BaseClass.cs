using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace IntegrationTest.HttpHelper;

public class BaseClass
{
    private readonly HttpClient _httpClient;
        
    public BaseClass()
    {
        _httpClient = new HttpClient();
    }
    // --------------------------------------------------------------------------------------------
    public void Authorization(string token)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
    // --------------------------------------------------------------------------------------------
    private ByteArrayContent CreateContent<T>(T obj)
    {
        var myContent = JsonConvert.SerializeObject(obj);
        var buffer = Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return byteContent;
    }
    // --------------------------------------------------------------------------------------------
    public async Task<TResult> GetAction<TResult>(string url, string queryString = "")
    {
        var response = await _httpClient.GetAsync(url + queryString);
        response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringResult);
        return result!;
    }
    // --------------------------------------------------------------------------------------------
    public async Task<TResult> PostAction<TResult, TValue>(string url, TValue value)
    {
        var response = await _httpClient.PostAsync(url, CreateContent(value));
        response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringResult);
        return result!;
    }
    // --------------------------------------------------------------------------------------------
    public async Task<TResult> PatchAction<TResult, TValue>(string url, TValue value, string queryString = "")
    {
        var response = await _httpClient.PatchAsync(url + queryString, CreateContent(value));
        response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringResult);
        return result!;
    }
    // --------------------------------------------------------------------------------------------
    public async Task<TResult> DeleteAction<TResult>(string url, string queryString = "")
    {
        var response = await _httpClient.DeleteAsync(url + queryString);
        response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringResult);
        return result!;
    }
    // --------------------------------------------------------------------------------------------
    public async Task<TResult> PutAction<TResult, TValue>(string url, TValue value)
    {
        var response = await _httpClient.PutAsync(url, CreateContent(value));
        response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var stringResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(stringResult);
        return result!;
    }
}
