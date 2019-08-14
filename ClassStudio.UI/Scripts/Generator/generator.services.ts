import { HttpClient } from '../httpClient';


export class GeneratorService {

  public async compile( input: string | null ): Promise<any> {
    if ( !input )
      null;

    const res = await HttpClient.post( '/generator/XMLStringToCSharp', {  } );

    if (res.ok) {
      return await res.json();

    } else {
      return res.statusText;
    }

  }

}
