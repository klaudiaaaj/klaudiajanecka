import { AutoMap } from '@automapper/classes';
export default class IdTokenPostDto {
  userId: number = 0;

  platformId: number | null = 0;

  @AutoMap()
  nickname: string = '';

  platformUserId: string | null = null;

  @AutoMap()
  exp: number = 0;

  @AutoMap()
  iat: number = 0;
}

export class IdTokenGetDto {
  tokenId: number = 0;

  userId: number = 0;

  platformId: number = 0;

  @AutoMap()
  nickname: string = '';

  platformUserId: number | null = null;

  @AutoMap()
  exp: number = 0;

  @AutoMap()
  iat: number = 0;

  createDate: Date = new Date(2018, 0o5, 0o5, 17, 23, 42, 11);
}
