# AltiView_AddinExample
An example project for building a custom AltiView add-in.

Instructions: Copy this project and it's submodules to a new repository. Build the user control interface as desired. The output will be a .DLL that can be ingested by AltiView as an add-in.

Communicating with the turret via AltiView: Altiview uses a Named Pipe called "altiview_pipe_addins" to exchange messages with Add-ins. All bytes sent to this named pipe will be forwarded to the turret, and all messages received from the turret will be output to the pipe.

For testing purposes, AltiView looks for the message "CLIENT_TEST_QUERY" (converted to bytes) to be received via the Named Pipe and responds with "SERVER_TEST_RESPONSE". In this way you can confirm communication with AltiView.

Running the Example Project: 
1) Open AltiView and leave it running in the background. This starts the Named Pipe server. 
2) Ensure that the "TestAppForAddIn" project is set as the startup project in the solution.
3) Run the test app and click the button "Send Test Message to AltiView!"
4) If AltiView successfully receives the test message it's response will be displayed via a MessageBox in the test project. If the test fails, no message box will appear.