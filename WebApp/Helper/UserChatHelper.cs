﻿using OpenTokSDK;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApp.Helper
{
    public class OpenTokSession
    {
        public string UserType { get; set; }
        public string RecipientName { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }
    }

    public class UserChatHelper
    {

        #region Declarations

        public static int TokBoxApiKey = Convert.ToInt32(ConfigurationManager.AppSettings["TokBoxApiKey"].ToString());
        private static string TokBoxSecretKey = ConfigurationManager.AppSettings["TokBoxSecretKey"].ToString();


        #endregion

        #region Public Methods

        public static OpenTokSession GetOpenTokSessionInformation(string senderId, string receiverId, string userType, string recipientName)
        {
            OpenTokSession oRet = null;

            var lstAllOpenTokSessions = (List<OpenTokSession>)(HttpContext.Current.Application["AllOpenTokSessions"]);
            if (lstAllOpenTokSessions != null)
            {
                oRet = lstAllOpenTokSessions.FirstOrDefault(x => (x.SenderId == senderId && x.ReceiverId == receiverId) || (x.SenderId == receiverId && x.ReceiverId == senderId));
            }
            else
            {
                lstAllOpenTokSessions = new List<OpenTokSession>();
            }

            if (oRet == null || string.IsNullOrEmpty(oRet.SessionId) || string.IsNullOrEmpty(oRet.TokenId))
            {
                //Initiate Open Tok Session
                var sessionId = GenerateOpenTokSession();
                var tokenId = GenerateOpenTokToken(sessionId);

                oRet = new OpenTokSession()
                {
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    SessionId = sessionId,
                    TokenId = tokenId,
                    UserType = userType,
                    RecipientName = recipientName
                };
                lstAllOpenTokSessions.Add(oRet);
            }

            HttpContext.Current.Application["AllOpenTokSessions"] = lstAllOpenTokSessions;
            return oRet;
        }

        public static string GenerateOpenTokSession()
        {
            var openTok = new OpenTok(TokBoxApiKey, TokBoxSecretKey);
            return openTok.CreateSession(mediaMode: MediaMode.RELAYED).Id;
        }

        public static string GenerateOpenTokToken(string sessionId)
        {
            var openTok = new OpenTok(TokBoxApiKey, TokBoxSecretKey);

            //By default token is valid for 24 hours. So does not need to modify it
            return openTok.GenerateToken(sessionId);
        }

        #endregion

    }
}