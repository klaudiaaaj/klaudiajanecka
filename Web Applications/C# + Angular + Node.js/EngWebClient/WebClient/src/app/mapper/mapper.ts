import { IdToken } from '@auth0/auth0-spa-js';
import { classes } from '@automapper/classes';
import { createMapper } from '@automapper/core';
import IdTokenPostDto from '../models/IdTokenDto';
import { User } from '../models/UserDto';

export const mapper = createMapper({
  name: 'someName',
  pluginInitializer: classes,
});

export function mapToIdToken(
  currentUser: User,
  platformId: number | null,
  userPlatformId: string | null,
  userToken: IdToken
): IdTokenPostDto {
  const dto = new IdTokenPostDto();

  dto.userId = currentUser.userId;
  dto.platformId = platformId;
  dto.platformUserId = userPlatformId;

  if (userToken.nickname) dto.nickname = userToken.nickname;
  if (userToken.exp) dto.exp = userToken.exp;
  if (userToken.iat) dto.iat = userToken.iat;

  return dto;
}
