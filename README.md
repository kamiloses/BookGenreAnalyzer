![image](https://github.com/user-attachments/assets/77118632-ff6a-4a3b-8a4c-76d9bf5e59b8)


<h1>🚀 How to Use 🚀</h1>

<h2>Predict Genre</h2>
<p>To get the genre predicted, send a <strong>POST</strong> request to:<br>
<code>http://localhost:5145/api/book/predict</code></p>

<h3>Example JSON in the request body:</h3>
<pre><code>{
  "TextFragment": "your text here"
}</code></pre>

<p>The API will respond with the predicted genre based on the provided text fragment.</p>

<hr>

<h2>Get Book Recommendations</h2>
<p>You can also request book recommendations based on a genre.<br>
Send a request with the genre as input, and the API will return the title of a book that matches that genre.</p>

<hr>

<h2>Training the Machine Learning Model</h2>
<p>
  Training the model is available only to privileged users.<br>
  One user is created by default as a seed user in the <code>UserSeedClass</code>.<br>
  Therefore, there is no possibility to create a new user.<br><br>
  
  To log in, send a <strong>POST</strong> request to:<br>
  <code>http://localhost:5145/api/user/login</code><br>
  with the following JSON body:
</p>
<pre><code>{
  "Username": "Kamiloses",
  "Password": "Kamiloses123!"
}</code></pre>
<p>
  You can train the model only after logging into the application with this user.
</p>

<hr>

<h1>🛠️ How to Run the Application 🛠️</h1>
