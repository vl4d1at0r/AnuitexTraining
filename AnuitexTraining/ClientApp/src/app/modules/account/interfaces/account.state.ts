export interface AccountState {
  accessToken: string,
  refreshToken: string,
  firstName: string,
  lastName: string,
  isConfirmedEmail: boolean,
  isPasswordReset: boolean,
  isLoggedIn: boolean;
  errors: string[]
}
