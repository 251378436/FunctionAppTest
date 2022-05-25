namespace ClassLibrary1
{
    public class Class1
    {
        public async Task<string> SendRequestAsync()
        {
            var content = new StringContent("{ 'name': 'morpheus', 'job': 'leader'}");
            using var client = new HttpClient();

            var response = await client.PostAsync($"https://reqres.in/api/users", content);

            return response.ToString();
        }
    }
}