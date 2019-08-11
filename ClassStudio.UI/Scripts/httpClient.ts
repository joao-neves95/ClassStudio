
export class HttpClient {
  public static async get( url ): Promise<Response> {
    return await fetch( url, {
      method: 'GET',
    } );
  }

  public static async post( url, data ): Promise<Response> {
    return await fetch( url, {
      method: 'POST',
      body: data
    } );
  }
}
