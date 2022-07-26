const Commando = require('discord.js-commando')
const config= require('./../config.json')

module.exports = class UpdatePermissionsCommand extends Commando.Command{
    constructor(client, message){
        super(client, {
            name: 'updatepermissions', 
            group: 'misc', 
            memberName: 'updatepermissions', 
            description: 'Update a channel\'s permissions', 
            userPermissions: [
                'ADMINISTRATOR'
            ], 
            argsType: 'multiple'
        },)    
        this.message=message;
    }
    instance_channel = undefined; 
    instance_role= undefined; 

    async assignRoleToChannel () {       
    var everyone = this.message.guild.roles.cache.find(role => role.id === config.everyoneRoleId)  
       this.instance_channel.overwritePermissions([
            {
                id: this.instance_role,
                allow: 'VIEW_CHANNEL', 
                deny: []
            },    
            {
                id: everyone,
                allow: [], 
                deny: 'VIEW_CHANNEL'
            },              
        ])
 
    }

async assignUserToRole (member) {
    console.log("instance role", this.instance_role.name)
       await member.roles.add(this.instance_role); 
    }

    async createChannel(cName){    
        let channel= await this.message.guild.channels
        .create(cName, {
          type: 'text',
        });     
        this.instance_channel=channel
    }

   async createRole(rName) {
        let role= await this.message.guild.roles.create({
            data:{
                name: rName, 
                color: Math.floor(Math.random()*16777215).toString(16),
            }    
        })

        this.instance_role=role;
    };
    
    async getChannel(cName){
       if(!this.ifExistsChannel(cName)){
            try {
                var response= await this.createChannel(cName)
                 if(this.message.guild.channels.cache.find(channel => channel.name === cName)!== undefined)
                 console.log("Channel created created", (this.message.guild.channels.cache.find(channel => channel.name === cName).name))
             }
             catch(err){
                 console.log('error:', err)
             }
        }
 
    }

    async getChannelAssign(cName){
        if(!this.ifExistsChannel(cName)){
             try {
                 var response= await this.createChannel(cName)
                  if(this.message.guild.channels.cache.find(channel => channel.name === cName)!== undefined)
                  console.log("Channel created created", (this.message.guild.channels.cache.find(channel => channel.name === cName).name))
              }
              catch(err){
                  console.log('error:', err)
              }
         }
  
     } 

    async getRole(rName){
            if(!this.ifExistsRole(rName)){
            try {
                await this.createRole(rName)
                if(this.message.guild.roles.cache.find(role => role.name === rName)!== undefined)
                console.log("Role created") 
            }
            catch(err){
                console.log('error:', err)
            }
        }    
    }

    async getUserAndAssignToRole(userId){        
            try{
                console.log("user", userId)
                var member = this.message.guild.members.cache.get(userId)    
                console.log("membeer", member)
                await this.assignUserToRole(member)   
                console.log("User: ", member.user.username, "has been assigned to the role")         
            }
            catch(err)
            {
                console.log('error:', err)
            }           
    }

    ifExistsRole(rolename) {
        var channel=this.message.guild.roles.cache.find(role => role.name === rolename);

        if(channel!== undefined){
            this.instance_role=channel;
            return true
        }
        return false;     
    }

    ifExistsChannel(channelName) {
        var role =this.message.guild.channels.cache.find(channel => channel.name === channelName);
        if(role!== undefined){
            this.instance_channel=role;
            return true
        }
        return false;     
    }
};

        
