# Use an official Node.js runtime as a parent image
FROM node:18 as builder

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json (if available)
COPY webapp/package*.json ./

# Install application dependencies
RUN npm install

# Copy the remaining application files
COPY webapp .

# Build the application for production, for prodution use argument --prod
#RUN npm run build --prod
RUN npm run build

# Use official Lighttpd base image
FROM alpine:latest

# Install Lighttpd
RUN apk add --no-cache lighttpd

# Set working directory
WORKDIR /var/www/lighttpd

# Copy Angular build files into the Lighttpd web root
COPY --from=builder /app/dist/webapp/browser /var/www/lighttpd/browser

# Copy Lighttpd configuration file
COPY lighttpd.conf /etc/lighttpd/lighttpd.conf

# Expose HTTP port
EXPOSE 80

# Run Lighttpd
CMD ["lighttpd", "-D", "-f", "/etc/lighttpd/lighttpd.conf"]
