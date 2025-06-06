using IRLIX.Comm.Emails.MailKit.Models;
using IRLIX.Core.General;
using MailKit.Net.Smtp;
using MimeKit;

namespace IRLIX.Comm.Emails.MailKit;

public interface IEmailSender
{
    ValueTask SendAsync(
        RecipientEmailDto recipient,
        CancellationToken ct = default);
}

public abstract class EmailSender : IEmailSender
{
    public abstract ValueTask SendAsync(
        RecipientEmailDto recipient,
        CancellationToken ct = default);

    protected static async ValueTask<bool> InnerSendAsync(
        EmailDto dto,
        CancellationToken ct)
    {
        var emailMessage = new MimeMessage(
            from: MailboxAddress
                .Parse(dto.Sender.Email)
                .ToOneItemList<InternetAddress>(),
            to: MailboxAddress
                .Parse(dto.Recipient.Email)
                .ToOneItemList<InternetAddress>(),
            subject: dto.Recipient.Subject,
            body: new TextPart(
                format: dto.Recipient.Format)
            {
                Text = dto.Recipient.Message
            });

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            host: dto.Sender.Host,
            port: dto.Sender.Port,
            cancellationToken: ct);
        await smtp.AuthenticateAsync(
            userName: dto.Sender.Email,
            password: dto.Sender.Password,
            cancellationToken: ct);

        await smtp.SendAsync(
            message: emailMessage,
            cancellationToken: ct);

        await smtp.DisconnectAsync(
            quit: true,
            cancellationToken: ct);

        return true;
    }
}
