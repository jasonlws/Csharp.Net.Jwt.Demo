# JSON Web Token (JWT)

JWT, or JSON Web Token, is a compact and self-contained way for securely transmitting information between parties as a JSON object. It is often used in authentication and information exchange scenarios.

A JWT is composed of three parts: Header, Payload, and Signature. These parts are encoded and concatenated with dots (.) as separators.


<img src="https://raw.githubusercontent.com/jasonlws/Csharp.Net.Jwt.Demo/master/resources/structure-of-jwt.gif"> 


**Header**: The header typically consists of two parts: the type of the token, which is JWT, and the signing algorithm being used, such as HMAC SHA256 or RSA.

**Payload**: The payload contains the claims. Claims are statements about an entity (typically, the user) and additional data. There are three types of claims: registered, public, and private.

- Registered claims: Predefined claims that are optional but recommended, such as iss (issuer), exp (expiration time), sub (subject), aud (audience), etc.
- Public claims: Custom claims created to share information, but they need to be defined in the IANA JSON Web Token Registry or be collision-resistant.
- Private claims: Custom claims created to share information between parties that agree to use them.

**Signature**: To create the signature part, you have to take the encoded header, the encoded payload, a secret, and the algorithm specified in the header. The signature is used to verify that the sender of the JWT is who it says it is and to ensure that the message wasn't changed along the way.

## How JWT Works

<img src="https://raw.githubusercontent.com/jasonlws/Csharp.Net.Jwt.Demo/master/resources/flow-jwt.gif"> 

1. Creation: A JWT is created by a server after the user successfully logs in. It contains claims that the server considers necessary for the client to carry.
2. Transmission: The JWT is sent to the client, typically in the HTTP Authorization header using the Bearer schema.

```makefile
Authorization: Bearer <token>
```

3. Verification: When the client makes subsequent requests, it includes the JWT. The server verifies the token's signature and ensures that it is valid (e.g., not expired, issued by the server).
4. Decoding: Although the information in the JWT can be decoded by anyone with base64 decoding, only the parties with the secret key can verify the signature and therefore trust the claims contained within the JWT.

## Benefits of JWT

- **Compact**: Because of their JSON format, JWTs are easy to send via HTTP headers, URLs, or POST parameters.
- **Self-contained**: JWTs carry their information, eliminating the need for server-side sessions.
- **Security**: They offer a secure way to transfer information by signing the payload, ensuring data integrity.

## Common Use Cases

- **Authentication**: JWT is widely used for authentication purposes. Once the user is logged in, each subsequent request will include the JWT, allowing the user to access routes, services, and resources that are permitted with that token.
- **Information Exchange**: JWTs can securely transmit information between parties because they can be signed, ensuring that the claims have not been altered.

## Algorithms

In JSON Web Tokens (JWT) authentication, different algorithms can be used to sign the token, each with its strengths and trade-offs.

### Symmetric Key Alogrithm - e.g. HS256

Uses a shared secret key for both signing and verification.

<img src="https://raw.githubusercontent.com/jasonlws/Csharp.Net.Jwt.Demo/master/resources/symmetric-key.gif"> 

**Advantages**

- **Simplicity**: Easy to implement since it uses a single secret key.
- **Performance**: Generally faster than asymmetric algorithms, making it suitable for high-performance applications.

**Disadvantages**

- **Security Risk**: Both the signer and verifier must share the same secret key, making it less secure if the key is exposed.
- **Scalability**: Sharing the same key across multiple systems or services can be challenging in distributed environments.


### Asymmetric Key Alogrithm - e.g. RSA256, ECDSA256

Uses a private key for signing and a public key for verification.

<img src="https://raw.githubusercontent.com/jasonlws/Csharp.Net.Jwt.Demo/master/resources/asymmetric-key.gif"> 

**Advantages**

- **Security**: More secure for scenarios where the signing and verification parties are different, as only the private key is used to sign, and the public key can be widely shared.
- **Scalability**: Easier to manage across distributed systems since public keys can be freely distributed without compromising security.

**Disadvantages**

- **Performance**: Slower than symmetric algorithms like HS256, which can impact performance in high-throughput systems.
- **Complexity**: More complex to implement due to key pair management.

### Use Cases

- **HS256**: Best suited for environments where performance is critical, and the key management can be tightly controlled, such as internal microservices or applications with a trusted client.
- **RSA256**: Ideal for scenarios where tokens need to be verified by multiple external parties or in distributed systems where key distribution is a concern.
- **ECDSA256**: A good choice for systems where computational efficiency and security are both priorities, especially when using constrained environments like IoT devices.

## Conclusion

JWT is a powerful tool for handling authentication and secure information exchange in web applications. Its compact and self-contained nature makes it ideal for microservices architectures and stateless applications.