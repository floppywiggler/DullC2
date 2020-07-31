using System;
using System.Collections.Generic;
using System.Text;
using TeamServer.Models;
using Xunit;

namespace TeamServer.Tests.ClientTests
{
    public class Client
    {
        [Fact]
        public void SuccessfulClientLogin()
        {
            var request = new ClientAuthenticationRequest { Nick = "carpetman", Password = "a" };
            var result = Controllers.ClientController.ClientLogin(request);

            Assert.Equal(ClientAuthenticationResult.AuthResult.LoginSuccess, result.Result);
            Assert.NotNull(result.Token);
        }
        [Fact]
        public void BadPasswordClientLogin()
        {
            var request = new ClientAuthenticationRequest { Nick = "carpetman", Password = "b" };
            var result = Controllers.ClientController.ClientLogin(request);

            Assert.Equal(ClientAuthenticationResult.AuthResult.BadPassword, result.Result);
            Assert.Null(result.Token);
        }
        [Fact]
        public void NickInUse()
        {
            var request = new ClientAuthenticationRequest { Nick = "carpetman", Password = "a" };
            Controllers.ClientController.ClientLogin(request);
            var result = Controllers.ClientController.ClientLogin(request);

            Assert.Equal(ClientAuthenticationResult.AuthResult.NickInUse, result.Result);
            Assert.Null(result.Token);
        }
        [Fact]
        public void InvalidRequest()
        {
            var request = new ClientAuthenticationRequest { Nick = "carpetman", Password = "" };
            var result = Controllers.ClientController.ClientLogin(request);

            Assert.Equal(ClientAuthenticationResult.AuthResult.InvalidRequest, result.Result);
            Assert.Null(result.Token);
        }

        [Fact]
        public void GetConnectedClients()
        {
            var request = new ClientAuthenticationRequest { Nick = "carpetman", Password = "a" };
            Controllers.ClientController.ClientLogin(request);
            request = new ClientAuthenticationRequest { Nick = "FunkyMoma", Password = "a" };
            Controllers.ClientController.ClientLogin(request);

            var result = Controllers.ClientController.GetConnectedClient();
            Assert.Equal(new List<string> { "carpetman", "FunkyMoma" }, result);
        }
    }


}
