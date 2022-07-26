import { Component, OnInit } from '@angular/core';
import { IdToken } from '@auth0/auth0-spa-js';
import { Platform } from 'src/app/models/PlatformDto';
import { User } from 'src/app/models/UserDto';
import { ApiTokenServiceService } from 'src/app/services/api-token-service.service';
import { ApiUserServiceService } from 'src/app/services/api-user-service.service';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { environment } from 'src/environments/environment';
import { mapToIdToken } from './../../mapper/mapper';
import IdTokenPostDto, { IdTokenGetDto } from './../../models/IdTokenDto';

@Component({
  selector: 'app-platforms',
  templateUrl: './platforms.component.html',
  styleUrls: ['./platforms.component.css'],
})
export class PlatformsComponent implements OnInit {
  currentUser = {} as User;
  platform: Platform[] = [];
  discord: boolean = false;
  github: boolean = false;
  platformId: number | null = null;
  userPlatformId: string | null = null;
  userToken = {} as IdToken;
  idTokenPostDto = {} as IdTokenPostDto;
  idTokenGetDto = {} as IdTokenGetDto;

  constructor(
    public userService: ApiUserServiceService,
    public authorizationService: AuthorizationService,
    public tokenService: ApiTokenServiceService
  ) {}

  async ngOnInit() {
    await this.getUser();
    await this.getUserToken();
    setTimeout(async () => {
      await this.getPlatform();
      await this.getIdTokenDto();
      await this.createIdToken();
    }, 3000);
  }

  async validateDiscord() {
    await this.userService
      .discordValidation()
      .then((res) => (this.discord = res));
  }

  async validateGithub() {
    await this.userService
      .githubValidation()
      .then((res) => (this.github = res));
  }

  async getUser() {
    this.userService.getUserById().subscribe((user) => {
      this.currentUser = user;
      this.validateDiscord(), this.validateGithub();
    });
  }

  async nextlLogin() {
    this.authorizationService.logout();
    setTimeout(async () => {
      this.authorizationService.login();
    }, 200);
  }

  async getUserToken() {
    this.authorizationService.getUserCredentials().subscribe((value) => {
      this.userToken = value;
    });
  }

  async createIdToken() {
    (await this.tokenService.createIdToken(this.idTokenPostDto)).subscribe(
      (response) => {
        this.updateUserIdToken(response.platformId, response.tokenId);
      }
    );
  }

  async updateUserIdToken(platformId: number, idToken: number) {
    await (
      await this.userService.userTokenUpdate(
        this.currentUser.userId,
        platformId,
        idToken
      )
    ).subscribe((updated) => {
      this.getUser();
    });
  }

  async getIdTokenDto() {
    this.idTokenPostDto = mapToIdToken(
      this.currentUser,
      this.platformId,
      this.userPlatformId,
      this.userToken
    );
  }

  async getPlatform() {
    if (this.userToken.sub?.includes('discord')) {
      this.platformId = 0;
      this.userPlatformId = this.userToken.sub?.replace('oauth2|discord|', '');
    } else if (this.userToken.sub?.includes('github')) {
      this.platformId = 1;
      this.userPlatformId = this.userToken.sub?.replace('github|', '');
    }
  }

  joinDc() {
    window.open(environment['invenation']);
  }
}
