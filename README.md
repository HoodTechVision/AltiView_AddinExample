# AltiView_AddinExample
An example project for building a custom AltiView add-in.

(6/22/2023: "Add-ins" are now just separate applications that communicating via a Named Pipe)

Instructions: Copy this project to a new repository.

Communicating with the turret via AltiView: Altiview uses a Named Pipe called **"altiview_pipe_addins"** to exchange messages with Add-ins. All bytes sent to this named pipe will be forwarded to the turret, and all messages received from the turret will be output to the pipe.

For testing purposes, AltiView looks for the message "CLIENT_TEST_QUERY" (converted to bytes) to be received via the Named Pipe and responds with "SERVER_TEST_RESPONSE". In this way you can confirm communication with AltiView.

Running the Example Project: 
1) Open AltiView and leave it running in the background. This starts the Named Pipe server. 
2) Run the test app and click the button "Send Test Message to AltiView!"
3) If AltiView successfully receives the test message its response will be displayed via a MessageBox in the test project. If the test fails, no message box will appear.