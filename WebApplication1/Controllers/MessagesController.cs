
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using WebApplication1.Models;
namespace ClientInterface.Controllers
{
    [RoutePrefix("api/messages")]
    public class MessagesController //: BaseController
    {
       // [System.Web.Http.HttpGet]
       // [Route("ReadMessagesFromMail")]
        //public IHttpActionResult ReadMessagesFromMail()
        //{
        //    try
        //    {
        //        List<int> messagesIds = new List<int>();
                //ReadMessagesFromMail
               // Result res = new MessagesDataWriter().ReadMessagesFromMail(messagesIds);
               // if (res.ResultId != 1)
                 //   return Error(res.ResultId);
               // List<Message> messages = new List<Message>();
               // MessageDataReader reader = new MessageDataReader();
                //foreach (int id in messagesIds)
                //{
                //  //  Message mes = reader.GetMessageById(id);
                //    if (mes != null)
                //    {
                //        messages.Add(mes);
                //    }
                //}

               // return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //       // return Error(1);
        //    }
        //}

      //  [System.Web.Http.HttpPut]
     //  [Route("SendAnswer")]
        //public IHttpActionResult SendAnswer([FromBody]Message newMessage)
        //{
        //    try
        //    {
        //       //int mesId = new MessagesDataWriter().SendAnswer(newMessage);
        //       // if (mesId == 0)
        //           // return Error(0);
        //      //  MessageDataReader reader = new MessageDataReader();
        //       // Message mes = reader.GetMessageById(mesId);

        //       // return Ok(mes);
        //    }
        //    catch (Exception ex)
        //    {
        //      //  return Error(1);
        //    }
        //}
    }
}