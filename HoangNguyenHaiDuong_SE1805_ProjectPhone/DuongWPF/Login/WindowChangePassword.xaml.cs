using BusinessObjects;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;

namespace DuongWPF.Login
{
	public partial class WindowChangePassword : Window
	{
		private readonly LoginObject loginObject;
		private readonly CustomerObject customerObject;
		private string generatedOtp;

		public WindowChangePassword()
		{
			InitializeComponent();
			loginObject = new LoginObject();
			customerObject = new CustomerObject();
		}

		private void ResetForm()
		{
			txtUserName.Text = null;
		}

		private string GenerateOtp()
		{
			var random = new Random();
			var otp = random.Next(100000, 999999).ToString();
			return otp;
		}

		private void Change_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string username = txtUserName.Text.Trim();

				if (string.IsNullOrWhiteSpace(username))
				{
					MessageBox.Show("Please input all fields", "Error", MessageBoxButton.OK);
					ResetForm();
					return;
				}

				var user = loginObject.FindUserByEmail(username);
				var cus = customerObject.GetCustomerByEmail(username);

				if (user == null && cus == null)
				{
					MessageBox.Show("Lỗi! Tài khoản không tồn tại.");
					return;
				}

				generatedOtp = GenerateOtp();
				SendOtpEmail(username, generatedOtp);
				MessageBox.Show("OTP đã được gửi tới email của bạn.");

				WindowVetifyOTP windowVetifyOTP = new WindowVetifyOTP(generatedOtp, username);
				windowVetifyOTP.Show();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Password change failed: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				ResetForm();
			}
		}

		private void SendOtpEmail(string toEmail, string otp)
		{
			var fromAddress = new MailAddress("DuongHNHHE172270@fpt.edu.vn", "QuanLyKhoDienThoai");
			var toAddress = new MailAddress(toEmail);
			const string fromPassword = "jyor qphe gomb kvgt"; 
			const string subject = "Your OTP Code";
			string body = $"Your OTP code is: {otp}";

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};

			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = subject,
				Body = body
			})
			{
				smtp.Send(message);
			}
		}

		private void Login_Click(object sender, MouseButtonEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
		}
	}
}
