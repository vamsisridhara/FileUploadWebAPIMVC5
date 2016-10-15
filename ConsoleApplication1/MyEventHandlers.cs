using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EMailViewModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToAddress { get; set; }
    }
    public interface IEmailSender
    {
        void sendMail(EMailViewModel emailModel);
    }
    public class EmailSender : IEmailSender
    {
        public void sendMail(EMailViewModel emailModel)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage()
            {
                Subject = emailModel.Subject,
                Body = emailModel.Body,
            };
            message.To.Add(new MailAddress(emailModel.ToAddress));
            smtpClient.Send(message);
        }
    }
    public class TestPage
    {
        public NameValueCollection Request { get; set; }
    }
    public enum EntityState { Retired, Restore }
    public interface IEntity
    {
        EntityState State { get; set; }
        void Restore();
        void Retire();
    }
    public interface IEntityRepository
    {
        IEntity GetById(int entityId);
        void SaveChangesTo(IEntity entity);
    }
    public class EntityRepository : IEntityRepository
    {
        public IEntity GetById(int entityId) { return null; }
        public void SaveChangesTo(IEntity entity) { }
    }
    public class MyEventHandlers
    {
        private IEmailSender _emailSender;
        private IEntityRepository _entityRepo;
        public MyEventHandlers()
        {
            _emailSender = new EmailSender();
            _entityRepo = new EntityRepository();
        }
        public void RestoreEntity(TestPage page)
        {
            var entity = getbyid(page.Request);
            if (entity != null)
            {
                if (entity.State != EntityState.Restore)
                {
                    throw new Exception("The entity is not restored!");
                }
                else
                {
                    entity.Restore();
                    _entityRepo.SaveChangesTo(entity);
                    _emailSender.sendMail(new EMailViewModel()
                    {
                        Subject = "Entity restored",
                        Body = entity.ToString() + " was restored.",
                        ToAddress = "nobody@mail.com"
                    });
                }
            }
            
        }
        private IEntity getbyid(NameValueCollection page)
        {
            IEntity _entity = null;
            if (page["EntityId"] != null)
            {
                Int32 entityId;
                Int32.TryParse(page["EntityId"].ToString(), out entityId);
                _entity = _entityRepo.GetById(entityId);
            }
            return _entity;
        }
        public void RetireEntity(TestPage page)
        {
            var entity = getbyid(page.Request);
            if (entity != null)
            {
                if (entity.State != EntityState.Retired)
                {
                    throw new Exception("The entity is not retired!");
                }
                else
                {
                    entity.Retire();
                    _entityRepo.SaveChangesTo(entity);
                    _emailSender.sendMail(new EMailViewModel()
                    {
                        Subject = "Entity retired",
                        Body = entity.ToString() + " was retired.",
                        ToAddress = "nobody@mail.com"
                    });
                }
            }
            
        }
    }
}
