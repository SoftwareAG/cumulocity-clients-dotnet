//
// HttpResponseMessageExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class HttpResponseMessageExtensions
{
 	 internal static async Task EnsureSuccessStatusCodeWithContentInfo(this HttpResponseMessage httpResponseMessage)
 	    {
 	        if (!httpResponseMessage.IsSuccessStatusCode)
 	        {
 	            var content = await httpResponseMessage.GetContent().ConfigureAwait(false);
 	            var messageBuilder = new StringBuilder();
 	            messageBuilder.Append($"Request failed. Status code: {httpResponseMessage.StatusCode}, Reason: {httpResponseMessage.ReasonPhrase}");
 	            if (content != string.Empty)
 	            {
 	                messageBuilder.Append($", Additional info: {content}");
 	            }
 	            var exception = new HttpRequestException(messageBuilder.ToString(), null);
 	            exception.SetStatusCode(httpResponseMessage.StatusCode);

 	            throw exception;
 	        }
 	    }

 	    private static async Task<string> GetContent(this HttpResponseMessage httpResponseMessage)
 	    {
 	        try
 	        {
 	            return await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
 	        }
 	        catch
 	        {
 	            return string.Empty;
 	        }
 	    }
}
