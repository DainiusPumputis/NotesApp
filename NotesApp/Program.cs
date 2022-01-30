using Microsoft.Extensions.DependencyInjection;
using NotesApp;

var startup = new Startup();

var serviceProvider = startup.ConfigureServices();

var noteApp = serviceProvider.GetService<NoteApp>();

noteApp.Start();
