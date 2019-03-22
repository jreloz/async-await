private async void GetSMS_Click(object sender, RoutedEventArgs e)
        {
            var result = await GetDDataAsync();
            PrintVal(result);
        }

        //Get Async
        private async Task<string> GetDDataAsync()
        {
            var searchref = TxtBoxPhone.Text;
            var httpClient = new HttpClient();
            var message = await httpClient.GetAsync("http://localhost:8012/sms-api/index.php?searchref="+ searchref + "");
            var content = await message.Content.ReadAsStringAsync();

            return content;
        }

              
        private async void PostSMS_Click(object sender, RoutedEventArgs e)
        {
            var result = await sendSMSAsync();
            PrintVal(result);
        }

        //Post Async
        private async Task<string> sendSMSAsync()
        {
          
            var phone = TxtBoxPhone.Text;
            var msg = TxtBoxMsg.Text;

            // You need to post the data as key value pairs:
            string postData = "sendSMS=sendSMS" + "&phone=" + phone + "&msg=" + msg + " ";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Post the data to the right place.
            Uri target = new Uri("http://localhost:8012/sms-api/index.php");
            WebRequest request = WebRequest.Create(target);

            request.Method = "POST";
            request.ConnectionGroupName = "sendSMS";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                WebHeaderCollection header = response.Headers;

                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    var res = await reader.ReadToEndAsync();
                    return res;
                }
            }

        }

        private void PrintVal(string value)
        {
           TxtBoxMsg.Text = TxtBoxMsg.Text + Environment.NewLine +value;
        }
