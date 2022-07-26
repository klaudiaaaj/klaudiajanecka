export class User{
    userId: number =0;
    discordTokenId: number= 0;
    githubTokenId: number=0; 
    appNickname: string="";  
    password: string = "";
}

export class RegisterUserDto {
    appNickname: string = '';
    password: string = '';
  }
  