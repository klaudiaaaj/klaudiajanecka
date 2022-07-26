const config = require("./config.json");
const command = require("./CommandHandler/command");
const UpdatePermissionsCommand = require("./update-permissions/updatepermission");
const Discord = require("discord.js");
const client = new Discord.Client();
const { Msg } = require("./Models/message");

client.on("ready", () => {
  console.log("The client is ready!");

  command(client, "createtextchannel", async (message) => {
    var updation = new UpdatePermissionsCommand(client, message);
    var splittedmessage = splitMessage(message);

    await updation.getChannel(splittedmessage.name);
    await updation.getRole(splittedmessage.name);
    await updation.assignRoleToChannel();
  });

  command(client, "assignuser", async (message) => {
    var updation = new UpdatePermissionsCommand(client, message);
    var splittedmessage = splitMessage(message);

    await updation.getChannel(splittedmessage.name);
    await updation.getRole(splittedmessage.name);
    await updation.getUserAndAssignToRole(splittedmessage.user);
  });
});

client.login(config.token);

function splitMessage(message) {
  const myMsg = new Msg();
  var tempmessage = message.content.replace("_bot ", "") + "";
  myMsg.command = tempmessage.split(" ")[0];
  myMsg.name = tempmessage.split(" ")[1] + "_" + tempmessage.split(" ")[2];
  if (myMsg.command == "assignuser") {
    myMsg.user = tempmessage.split(" ")[3];
  }
  return myMsg;
}
