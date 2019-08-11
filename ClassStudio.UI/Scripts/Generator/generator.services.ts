import { HttpClient } from '../httpClient';


export class GeneratorView {

  public async compile(): Promise<any> {
    const res = await HttpClient.post( '', {} );

    if ( res.ok )
      return await res.json();
  }

}
