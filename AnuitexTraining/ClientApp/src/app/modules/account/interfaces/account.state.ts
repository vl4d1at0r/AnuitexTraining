export interface AccountState {
  accessToken: string,
  refreshToken: string,
  firstName: string,
  lastName: string,
  isConfirmedEmail: boolean,
  isPasswordReset: boolean,
  errors: string[]
}
