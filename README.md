<div align="center">
  <h1>🌴 Palm Hills Backend API</h1>
  <p><strong>A modern, scalable backend built with .NET 10</strong></p>
</div>

<hr />

<h2>📌 Overview</h2>
<p>
  This project is a <b>Web API</b> developed for the <b>Palm Hills</b> application. [cite_start]It leverages the latest <b>.NET 10</b> framework to provide a high-performance and maintainable foundation for backend services[cite: 2]. The project includes integrated email services, CORS support, and structured logging.
</p>

<h2>🚀 Key Features</h2>
<ul>
  [cite_start]<li><b>Advanced Email Service:</b> Integrated with <b>MailKit</b> to handle SMTP communication via Gmail[cite: 2, 1].</li>
  [cite_start]<li><b>Modern Stack:</b> Powered by <b>.NET 10</b> and <b>Entity Framework Core</b>[cite: 2].</li>
  <li><b>CORS Policy:</b> Pre-configured <code>FrontendPolicy</code> to allow cross-origin requests from any header or method.</li>
  <li><b>Clean Architecture:</b> Uses Dependency Injection for <code>IEmailService</code> and clear separation of concerns.</li>
</ul>

<h2>🛠 Technology Stack</h2>
<table width="100%">
  <tr>
    <td><b>Framework</b></td>
    [cite_start]<td>ASP.NET Core (net10.0) [cite: 2]</td>
  </tr>
  <tr>
    <td><b>Language</b></td>
    <td>C#</td>
  </tr>
  <tr>
    <td><b>Libraries</b></td>
    [cite_start]<td>MailKit (4.14.1), Entity Framework Core (10.0.1) [cite: 2]</td>
  </tr>
  <tr>
    <td><b>Configuration</b></td>
    <td>JSON-based settings for SMTP and Logging</td>
  </tr>
</table>

<h2>⚙️ Configuration</h2>
<p>The system uses the following SMTP settings for email delivery:</p>
<pre>
- Server: smtp.gmail.com
- Port: 587
- Sender: palmHills
</pre>

<h2>📦 Installation & Setup</h2>
<ol>
  <li>Clone the repository.</li>
  <li>Install <b>.NET 10 SDK</b>.</li>
  <li>Restore packages: <code>dotnet restore</code></li>
  <li>Run the application: <code>dotnet run</code></li>
</ol>

<hr />

<div align="center">
  <sub>Built with ❤️ using ASP.NET Core</sub>
</div>
